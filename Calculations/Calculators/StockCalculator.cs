﻿using Calculations.Dto;
using Calculations.Interfaces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calculations.Calculators
{
    class StockCalculator : ICalculator<StockCalculatorDto>
    {

        private readonly IExchangeRates _exchangeRates;

        public StockCalculator(IExchangeRates exchangeRates)
        {
            _exchangeRates = exchangeRates;
        }

        public async Task<T> Calculate<T>() where T : StockCalculatorDto
        {
            using (var context = new ApplicationDbContext())
            {
                IList<StockEntity> stockEntities = new List<StockEntity>();
                var stockClosedPositions = context.ClosedPositions.Include(c => c.TransactionReports);

                foreach (var stockClosedPosition in stockClosedPositions)
                {
                    StockEntity stockEntity = new StockEntity
                    {
                        Name = stockClosedPosition.Operation,
                        PurchaseDate = stockClosedPosition.OpeningDate,                       
                        SellDate = stockClosedPosition.ClosingDate,
                        CurrencySymbol = "USD",
                        PositionId = stockClosedPosition.PositionId ?? 0                        
                    };
                    
                    stockEntity.OpeningValue = stockClosedPosition.OpeningRate * stockClosedPosition.Units ?? 0;
                    stockEntity.ClosingValue = stockClosedPosition.ClosingRate * stockClosedPosition.Units ?? 0;
                    stockEntity.Profit = stockEntity.ClosingValue - stockEntity.OpeningValue;                    

                    ExchangeRateEntity exchangeRateEntity = await _exchangeRates.GetRateForPreviousDay(stockEntity.CurrencySymbol, stockEntity.SellDate);
                    stockEntity.ClosingExchangeRate = exchangeRateEntity.Rate;

                    exchangeRateEntity = await _exchangeRates.GetRateForPreviousDay(stockEntity.CurrencySymbol, stockEntity.PurchaseDate);
                    stockEntity.OpeningExchangeRate = exchangeRateEntity.Rate;

                    stockEntity.LossExchangedValue = Math.Round(stockEntity.OpeningValue * stockEntity.OpeningExchangeRate, 2);
                    stockEntity.GainExchangedValue = Math.Round(stockEntity.ClosingValue * stockEntity.ClosingExchangeRate, 2);


                    stockEntities.Add(stockEntity);

                    if (stockClosedPosition.TransactionReports != null)
                    {
                        context.RemoveRange(stockClosedPosition.TransactionReports);
                    }

                    context.Remove(stockClosedPosition);
                }

                await context.AddRangeAsync(stockEntities);

                try
                {
                    await context.SaveChangesAsync();
                    decimal totalLoss = stockEntities.Sum(c => c.LossExchangedValue);
                    decimal totalGain = stockEntities.Sum(c => c.GainExchangedValue);

                    var stockCalculatorDto = new StockCalculatorDto
                    {
                        Cost = totalLoss,
                        Revenue = totalGain,
                        Income = totalGain - totalLoss
                    };

                    return (T)stockCalculatorDto;                            
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }

            }

        }        
    }
}
