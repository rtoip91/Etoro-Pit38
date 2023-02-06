﻿namespace ExcelReader.Converters;

internal record Country
{
    public string Name { get; }
    public string TwoLetterCode { get; }
    public string ThreeLetterCode { get; }
    public string NumericCode { get; }

    private Country(string name, string twoLetterCode, string threeLetterCode, string numericCode)
    {
        Name = name;
        TwoLetterCode = twoLetterCode;
        ThreeLetterCode = threeLetterCode;
        NumericCode = numericCode;
    }

    public static readonly Country[] List = {
         new Country("Afganistan", "AF", "AFG", "004"),
         new Country("Albania", "AL", "ALB", "008"),
         new Country("Algieria", "DZ", "DZA", "012"),
         new Country("Samoa Amerykańskie", "AS", "ASM", "016"),
         new Country("Andora", "AD", "AND", "020"),
         new Country("Angola", "AO", "AGO", "024"),
         new Country("Anguilla", "AI", "AIA", "660"),
         new Country("Antyle Holenderskie", "AN", "ANT", "530"),
         new Country("Antarktyda", "AQ", "ATA", "010"),
         new Country("Antigua i Barbuda", "AG", "ATG", "028"),
         new Country("Argentyna", "AR", "ARG", "032"),
         new Country("Armenia", "AM", "ARM", "051"),
         new Country("Aruba", "AW", "ABW", "533"),
         new Country("Australia", "AU", "AUS", "036"),
         new Country("Austria", "AT", "AUT", "040"),
         new Country("Azerbejdżan", "AZ", "AZE", "031"),
         new Country("Bahamy", "BS", "BHS", "044"),
         new Country("Bahrajn", "BH", "BHR", "048"),
         new Country("Bangladesz", "BD", "BGD", "050"),
         new Country("Barbados", "BB", "BRB", "052"),
         new Country("Białoruś", "BY", "BLR", "112"),
         new Country("Belgia", "BE", "BEL", "056"),
         new Country("Belize", "BZ", "BLZ", "084"),
         new Country("Benin", "BJ", "BEN", "204"),
         new Country("Bermudy", "BM", "BMU", "060"),
         new Country("Bhutan", "BT", "BTN", "064"),
         new Country("Boliwia, wielonarodowe państwo", "BO", "BOL", "068"),
         new Country("Bonaire, Sint Eustatius i Saba", "BQ", "BES", "535"),
         new Country("Bośnia i Hercegowina", "BA", "BIH", "070"),
         new Country("Botswana", "BW", "BWA", "072"),
         new Country("Wyspa Bouveta", "BV", "BVT", "074"),
         new Country("Brazylia", "BR", "BRA", "076"),
         new Country("Brytyjskie Terytorium Oceanu Indyjskiego", "IO", "IOT", "086"),
         new Country("Brunei Darussalam", "BN", "BRN", "096"),
         new Country("Bułgaria", "BG", "BGR", "100"),
         new Country("Burkina Faso", "BF", "BFA", "854"),
         new Country("Burundi", "BI", "BDI", "108"),
         new Country("Cabo Verde", "CV", "CPV", "132"),
         new Country("Kambodża", "KH", "KHM", "116"),
         new Country("Kamerun", "CM", "CMR", "120"),
         new Country("Kanada", "CA", "CAN", "124"),
         new Country("Kajmany", "KY", "CYM", "136"),
         new Country("Republika Środkowoafrykańska", "CF", "CAF", "140"),
         new Country("Czad", "TD", "TCD", "148"),
         new Country("Chile", "CL", "CHL", "152"),
         new Country("Chiny", "CN", "CHN", "156"),
         new Country("Wyspa Bożego Narodzenia", "CX", "CXR", "162"),
         new Country("Wyspy Kokosowe (Keelinga)", "CC", "CCK", "166"),
         new Country("Kolumbia", "CO", "COL", "170"),
         new Country("Komory", "KM", "COM", "174"),
         new Country("Kongo", "CG", "COG", "178"),
         new Country("Kongo, Demokratyczna Republika", "CD", "COD", "180"),
         new Country("Wyspy Cooka", "CK", "COK", "184"),
         new Country("Kostaryka", "CR", "CRI", "188"),
         new Country("Wybrzeże Kości Słoniowej", "CI", "CIV", "384"),
         new Country("Chorwacja", "HR", "HRV", "191"),
         new Country("Kuba", "CU", "CUB", "192"),
         new Country("Curaçao", "CW", "CUW", "531"),
         new Country("Cypr", "CYP", "CYP", "196"),
         new Country("Czechy", "CZ", "CZE", "203"),
         new Country("Dania", "DK", "DNK", "208"),
         new Country("Dżibuti", "DJ", "DJI", "262"),
         new Country("Dominika", "DM", "DMA", "212"),
         new Country("Dominikana", "DO", "DOM", "214"),
         new Country("Ekwador", "WE", "ECU", "218"),
         new Country("Egipt", "EG", "EGY", "818"),
         new Country("Salwador", "SV", "SLV", "222"),
         new Country("Gwinea Równikowa", "GQ", "GNQ", "226"),
         new Country("Erytrea", "ER", "ERI", "232"),
         new Country("Estonia", "EE", "EST", "233"),
         new Country("Eswatini", "SZ", "SWZ", "748"),
         new Country("Etiopia", "ET", "ETH", "231"),
         new Country("Falklandy (Malwiny)", "FK", "FLK", "238"),
         new Country("Wyspy Owcze", "FO", "FRO", "234"),
         new Country("Fidżi", "FJ", "FJI", "242"),
         new Country("Finlandia", "FI", "FIN", "246"),
         new Country("Francja", "FR", "FRA", "250"),
         new Country("Gujana Francuska", "GF", "GUF", "254"),
         new Country("Polinezja Francuska", "PF", "PYF", "258"),
         new Country("Francuskie Terytoria Południowe", "TF", "ATF", "260"),
         new Country("Gabon", "GA", "GAB", "266"),
         new Country("Gambia", "GM", "GMB", "270"),
         new Country("Gruzja", "GE", "GEO", "268"),
         new Country("Niemcy", "DE", "DEU", "276"),
         new Country("Ghana", "GH", "GHA", "288"),
         new Country("Gibraltar", "GI", "GIB", "292"),
         new Country("Grecja", "GR", "GRC", "300"),
         new Country("Grenlandia", "GL", "GRL", "304"),
         new Country("Grenada", "GD", "GRD", "308"),
         new Country("Gwadelupa", "GP", "GLP", "312"),
		 new Country("Guam", "GU", "GUM", "316"),
         new Country("Gwatemala", "GT", "GTM", "320"),
         new Country("Guernsey", "GG", "GGY", "831"),
         new Country("Gwinea", "GN", "GIN", "324"),
         new Country("Gwinea Bissau", "GW", "GNB", "624"),
         new Country("Gujana", "GY", "GUY", "328"),
         new Country("Haiti", "HT", "HTI", "332"),
         new Country("Wyspy Heard i McDonalda", "HM", "HMD", "334"),
         new Country("Stolica Apostolska", "VA", "VAT", "336"),
         new Country("Honduras", "HN", "HND", "340"),
         new Country("Hongkong", "HK", "HKG", "344"),
         new Country("Węgry", "HU", "HUN", "348"),
         new Country("Islandia", "IS", "ISL", "352"),
         new Country("Indie", "IN", "IND", "356"),
         new Country("Indonezja", "ID", "IDN", "360"),
         new Country("Iran, Islamska Republika", "IR", "IRN", "364"),
         new Country("Irak", "IQ", "IRQ", "368"),
         new Country("Irlandia", "IE", "IRL", "372"),
         new Country("Wyspa Man", "IM", "IMN", "833"),
         new Country("Izrael", "IL", "ISR", "376"),
         new Country("Włochy", "IT", "ITA", "380"),
         new Country("Jamajka", "JM", "JAM", "388"),
         new Country("Japonia", "JP", "JPN", "392"),
         new Country("Jersey", "JE", "JEY", "832"),
         new Country("Jordania", "JO", "JOR", "400"),
         new Country("Kazachstan", "KZ", "KAZ", "398"),
         new Country("Kenia", "KE", "KEN", "404"),
         new Country("Kiribati", "KI", "KIR", "296"),
         new Country("Korea, Ludowo-Demokratyczna Republika", "KP", "PRK", "408"),
         new Country("Republika Korei", "KR", "KOR", "410"),
         new Country("Kuwejt", "KW", "KWT", "414"),
         new Country("Kirgistan", "KG", "KGZ", "417"),
         new Country("Laotańska Republika Ludowo-Demokratyczna", "LA", "LAO", "418"),
         new Country("Łotwa", "LV", "LVA", "428"),
         new Country("Liban", "LB", "LBN", "422"),
         new Country("Lesotho", "LS", "LSO", "426"),
         new Country("Liberia", "LR", "LBR", "430"),
         new Country("Libia", "LY", "LBY", "434"),
         new Country("Liechtenstein", "LI", "LIE", "438"),
         new Country("Litwa", "LT", "LTU", "440"),
         new Country("Luksemburg", "LU", "LUX", "442"),
         new Country("Makao", "MO", "MAC", "446"),
         new Country("Madagaskar", "MG", "MDG", "450"),
         new Country("Malawi", "MW", "MWI", "454"),
         new Country("Malezja", "MY", "MYS", "458"),
         new Country("Malediwy", "MV", "MDV", "462"),
         new Country("Mali", "ML", "MLI", "466"),
         new Country("Malta", "MT", "MLT", "470"),
         new Country("Wyspy Marshalla", "MH", "MHL", "584"),
         new Country("Martynika", "MQ", "MTQ", "474"),
         new Country("Mauretania", "MR", "MRT", "478"),
         new Country("Mauritius", "MU", "MUS", "480"),
         new Country("Majotta", "YT", "MYT", "175"),
         new Country("Meksyk", "MX", "MEX", "484"),
         new Country("Federalne Stany Mikronezji", "FM", "FSM", "583"),
         new Country("Mołdawia, Republika", "MD", "MDA", "498"),
         new Country("Monako", "MC", "MCO", "492"),
         new Country("Mongolia", "MN", "MNG", "496"),
         new Country("Czarnogóra", "ME", "MNE", "499"),
         new Country("Montserrat", "MS", "MSR", "500"),
         new Country("Maroko", "MA", "MAR", "504"),
         new Country("Mozambik", "MZ", "MOZ", "508"),
         new Country("Myanmar", "MM", "MMR", "104"),
         new Country("Namibia", "NA", "NAM", "516"),
         new Country("Nauru", "NR", "NRU", "520"),
         new Country("Nepal", "NP", "NPL", "524"),
         new Country("Holandia", "NL", "NLD", "528"),
         new Country("Nowa Kaledonia", "NC", "NCL", "540"),
         new Country("Nowa Zelandia", "NZ", "NZL", "554"),
         new Country("Nikaragua", "NI", "NIC", "558"),
         new Country("Niger", "NE", "NER", "562"),
         new Country("Nigeria", "NG", "NGA", "566"),
         new Country("Niue", "NU", "NIU", "570"),
         new Country("Wyspa Norfolk", "NF", "NFK", "574"),
         new Country("Mariany Północne", "MP", "MNP", "580"),
         new Country("Macedonia Północna", "MK", "MKD", "807"),
         new Country("Norwegia", "NIE", "NIE", "578"),
         new Country("Oman", "OM", "OMN", "512"),
         new Country("Pakistan", "PK", "PAK", "586"),
         new Country("Palau", "PW", "PLW", "585"),
         new Country("Palestyna, stan", "PS", "PSE", "275"),
         new Country("Panama", "PA", "PAN", "591"),
         new Country("Papua-Nowa Gwinea", "PG", "PNG", "598"),
         new Country("Paragwaj", "PY", "PRY", "600"),
         new Country("Peru", "PE", "PER", "604"),
         new Country("Filipiny", "PH", "PHL", "608"),
         new Country("Pitcairn", "PN", "PCN", "612"),
         new Country("Polska", "PL", "POL", "616"),
         new Country("Portugalia", "PT", "PRT", "620"),
         new Country("Portoryko", "PR", "PRI", "630"),
         new Country("Katar", "QA", "QAT", "634"),
         new Country("Réunion", "RE", "REU", "638"),
		 new Country("Rumunia", "RO", "ROU", "642"),
         new Country("Federacja Rosyjska", "RU", "RUS", "643"),
         new Country("Rwanda", "RW", "RWA", "646"),
         new Country("Saint Barthélemy", "BL", "BLM", "652"),
         new Country("Święta Helena, Wniebowstąpienie i Tristan da Cunha", "SH", "SHN", "654"),
         new Country("Saint Kitts i Nevis", "KN", "KNA", "659"),
         new Country("Saint Lucia", "LC", "LCA", "662"),
         new Country("Saint Martin (część francuska)", "MF", "MAF", "663"),
         new Country("Saint-Pierre i Miquelon", "PM", "SPM", "666"),
         new Country("Saint Vincent i Grenadyny", "VC", "VCT", "670"),
         new Country("Samoa", "WS", "WSM", "882"),
         new Country("San Marino", "SM", "SMR", "674"),
         new Country("Wyspy Świętego Tomasza i Książęca", "ST", "STP", "678"),
         new Country("Arabia Saudyjska", "SA", "SAU", "682"),
         new Country("Senegal", "SN", "SEN", "686"),
         new Country("Serbia", "RS", "SRB", "688"),
         new Country("Seszele", "SC", "SYC", "690"),
         new Country("Sierra Leone", "SL", "SLE", "694"),
         new Country("Singapur", "SG", "SGP", "702"),
         new Country("Sint Maarten (część holenderska)", "SX", "SXM", "534"),
         new Country("Słowacja", "SK", "SVK", "703"),
         new Country("Słowenia", "SI", "SVN", "705"),
         new Country("Wyspy Salomona", "SB", "SLB", "090"),
         new Country("Somalia", "SO", "SOM", "706"),
         new Country("Republika Południowej Afryki", "ZA", "ZAF", "710"),
         new Country("Georgia Południowa i Sandwich Południowy", "GS", "SGS", "239"),
         new Country("Sudan Południowy", "SS", "SSD", "728"),
         new Country("Hiszpania", "ES", "ESP", "724"),
         new Country("Sri Lanka", "LK", "LKA", "144"),
         new Country("Sudan", "SD", "SDN", "729"),
         new Country("Surinam", "SR", "SUR", "740"),
         new Country("Svalbard i Jan Mayen", "SJ", "SJM", "744"),
         new Country("Szwecja", "SE", "SWE", "752"),
         new Country("Szwajcaria", "CH", "CHE", "756"),
         new Country("Syryjska Republika Arabska", "SY", "SYR", "760"),
         new Country("Tajwan, prowincja Chin", "TW", "TWN", "158"),
         new Country("Tadżykistan", "TJ", "TJK", "762"),
         new Country("Tanzania, Zjednoczona Republika", "TZ", "TZA", "834"),
         new Country("Tajlandia", "TH", "THA", "764"),
         new Country("Timor Wschodni", "TL", "TLS", "626"),
         new Country("Togo", "TG", "TGO", "768"),
         new Country("Tokelau", "TK", "TKL", "772"),
         new Country("Tonga", "TO", "TON", "776"),
         new Country("Trynidad i Tobago", "TT", "TTO", "780"),
         new Country("Tunezja", "TN", "TUN", "788"),
         new Country("Turcja", "TR", "TUR", "792"),
         new Country("Turkmenistan", "TM", "TKM", "795"),
         new Country("Wyspy Turks i Caicos", "TC", "TCA", "796"),
         new Country("Tuvalu", "TV", "TUV", "798"),
         new Country("Uganda", "UG", "UGA", "800"),
         new Country("Ukraina", "UA", "UKR", "804"),
         new Country("Zjednoczone Emiraty Arabskie", "AE", "ARE", "784"),
         new Country("Zjednoczone Królestwo Wielkiej Brytanii i Irlandii Północnej", "GB", "GBR", "826"),
         new Country("Stany Zjednoczone Ameryki", "USA", "USA", "840"),
         new Country("Dalekomorskie Wyspy Mniejsze Stanów Zjednoczonych", "UM", "UMI", "581"),
         new Country("Urugwaj", "UY", "URY", "858"),
         new Country("Uzbekistan", "UZ", "UZB", "860"),
         new Country("Vanuatu", "VU", "VUT", "548"),
         new Country("Wenezuela, Republika Boliwariańska", "VE", "VEN", "862"),
         new Country("Wietnam", "VN", "VNM", "704"),
         new Country("Wyspy Dziewicze, Brytyjskie", "VG", "VGB", "092"),
         new Country("Wyspy Dziewicze, USA", "VI", "VIR", "850"),
         new Country("Wallis i Futuna", "WF", "WLF", "876"),
         new Country("Sahara Zachodnia", "EH", "ESH", "732"),
         new Country("Jemen", "YE", "YEM", "887"),
         new Country("Zambia", "ZM", "ZMB", "894"),
         new Country("Zimbabwe", "ZW", "ZWE", "716"),
         new Country("Wyspy Alandzkie", "AX", "ALA", "248")
    };
}