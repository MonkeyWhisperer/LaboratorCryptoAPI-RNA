Cod sursă Blazor Web Assembly pentru **https://laboratorcryptoapi-rna20241216173229.azurewebsites.net** unde puteți vizuliza piața criptomonedelor cu paginare infinită la scroll și descărca lista afișată ca Excel în format .xlsx 

Documentație API CoinGecko https://docs.coingecko.com/v3.0.1/reference/introduction 

Documentație + suport cod sursă https://docs.google.com/document/d/1k6DIALXDzQDBs0Tpr5qhnJKIfd-zm0oWJw1w5vg3H8Y/edit?usp=sharing

Pentru rulare cod pe dispozitiv propriu trebuie cerută cheie de dezvoltator de la CoinGecko https://www.coingecko.com/en/developers/dashboard și pusă în appsettings.json

"CoinGeckoApi": {
  "BaseUrl": "https://api.coingecko.com/api/v3",
  "ApiKey": "TREBUIE CERUTĂ"
}
