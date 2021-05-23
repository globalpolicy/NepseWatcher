# NepseWatcher
A program to screen and monitor NEPSE stocks  
## Important:
* NepseWatcher tries to download listed companies from nepalipaisa.com. If it cannot, a fallback list included as a resource in the binary is used instead.  
* NepseWatcher uses Selenium Chromedriver to load charts of companies the user selects. So, Google Chrome is required. Similarly, a corresponding version of Google Chrome Driver executable needs to be placed inside the program directory. Technical analysis charts from systemxlite.com or nepsealpha.com can be used for this purpose. Simply load the right URL into the web browser window.  
* NepseWatcher requires .netcore 3.1 to run.
* The application's icon has been created with https://logomakr.com/
* Companies' stock prices are downloaded from systemxlite.com
## Features:
* __Screener__: Analyse companies' stocks based on the following metrics:  
  * `Moving Average`:
  Custom averaging period with the possibility of analysing data points falling below the corresponding Moving Average curve  
  * `Candlestick Patterns`:
  Scan for the six most common candlestick patterns for trading signals  
  * `ROI`:
  Analyse companies' stocks for their average Return On Investments over the past year. Linear and logarithmic weighting schemes available  
* __Watchlist__:
  Can make use of a CSV file to store and load watchlist for companies. Can calculate deductibles-incorporated investment, sale value, profit and ROI for each company in the watchlist  
* __Chart browser__:  
  Load candlestick chart for any selected company
## Screenshots:
<a href="https://ibb.co/XW8n2Cq"><img src="https://i.ibb.co/rQsB7wV/shot1.png" alt="shot1" border="2"></a>  
<a href="https://ibb.co/7kTBhGv"><img src="https://i.ibb.co/tLNnRbB/shot1-2.png" alt="shot1-2" border="2"></a>  
<a href="https://ibb.co/F06pZLP"><img src="https://i.ibb.co/hZs0QJq/shot1-3.png" alt="shot1-3" border="2"></a>  
<a href="https://ibb.co/NLb7686"><img src="https://i.ibb.co/zSDNhyh/shot.png" alt="shot" border="2"></a>  
<a href="https://ibb.co/vjpYm65"><img src="https://i.ibb.co/G5yTk4w/shot1-5.png" alt="shot1-5" border="2"></a>  
<a href="https://ibb.co/dfHYhMq"><img src="https://i.ibb.co/YNVsrQM/shot1-4.png" alt="shot1-4" border="2"></a>
<a href="https://ibb.co/g9qskdp"><img src="https://i.ibb.co/jf07nz2/Untitled.png" alt="chart" border="2"></a>
