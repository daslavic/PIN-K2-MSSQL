# Koristi se COINMARKETCAP PRIVATE API KEY od VSITE accounta
##############################################################################
from requests import Request, Session
from requests.exceptions import ConnectionError, Timeout, TooManyRedirects
import json
import datetime
import pyodbc 
import os
os.system('cls')
##############################################################################

# DEFINIRANJE FUNKCIJE ZA PUNJENJE MS SQL BAZE - TABLICA KriptTrade
def NapuniBazu(a,b,c,d,e,f,g):
 #print(a,b,c,d,e,f,g)
 print(" ",'{:<6.0f}'.format(a),'{:<9s}'.format(b),'{:<22s}'.format(c),'{:>15.3f}'.format(d),'{:>14.2f}'.format(e),"%",'{:>15.2f}'.format(f),"%",'{:>17.2f}'.format(g),"%")
 #print(dot)

 cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=CNZGNCDSL-T580\SQLEXPRESS;"
                      "Database=KriptoDB;"
                      "Trusted_Connection=yes;")

 cursor = cnxn.cursor()
 cursor.execute("UPDATE KriptoDB.dbo.KriptoTrades SET KriptoRank=?, Symbol=?, USD=?, DatumUnosa=GETDATE(), Change_1H=?, Change_24H=?, Change_7D=? WHERE KriptoName=?",(a,b,d,e,f,g,c))
 #cursor.execute("INSERT INTO kripto.dbo.KriptoTrade (KriptoRank, Symbol, KriptoName) VALUES ('%s','%s','%s')"%(a,b,c))
 #cursor.execute("INSERT INTO kripto.dbo.KriptoTrade (KriptoID) VALUES ('%s')"%(b))
 #cursor.execute("UPDATE kripto.dbo.KriptoTrade SET KriptoID=? WHERE KriptoName=?", (b))
 cnxn.commit()
 cursor.close()
 cnxn.close()
  
#  return "KUPUJ"

# DEFINIRANJE VARIJABLI dash i dot i datuma unosa za izgled
dash = '-' * 115
dot = '.' * 115
DatumUnosa = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")

# DEFINIRANJE Kripto Valuta za TRADE
# kripto = ["bitcoin", "ethereum", "xrp", "stellar", "litecoin", "eos", "bitcoin-cash", "cardano", "tron", "monero", "dash", "iota", "cosmos", "ethereum-classic", "neo", "maker", "basic-attention-token", "zcash", "vechain", "achain", "dogecoin", "chainlink", "augur", "melon", "gnosis-gno", "qtum", "lisk", "icon", "zilliqa", "komodo", "verge", "neblio", "civic", "ark", "aelf", "pivx", "polymath-network"]

 #print(row)
 
# DEFINIRANE URL ZA DOHVAT PODATAKA
url = ' https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest'
parameters = {
      'start': '1',
      'limit': '500',

# UBACIVANJE PRIVATE API KEY      
}
headers = {
      'Accepts': 'application/json',
      'X-CMC_PRO_API_KEY': 'c4ded0ad-f8c0-41c3-8a3f-e8efb598c295',
}

session = Session()
session.headers.update(headers)

# DOHVAT PODATAKA I SPREMANJE SVEGA VARIJABLU DATA
try:
      response = session.get(url, params=parameters)
      data = json.loads(response.text)
#      print(data)

except (ConnectionError, Timeout, TooManyRedirects) as e:
   print(e)

print(dash)
print(dash)
print('{:>45s}'.format(" Kripto BOT - PUNJENJE BAZE "), "  BEGIN:", datetime.datetime.now())
print(dash)
print()
print('{:<7s}'.format("RANK:"),'{:<11s}'.format("SYMBOL:"), '{:<16s}'.format("NAME:"),'{:>19s}'.format("USD:"),'{:>19s}'.format("CHANGE 1H:"),'{:>18s}'.format("CHANGE 24H:"),'{:>18s}'.format("CHANGE 7D:"))

print(dot)

for x in data['data']:
 conn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                      "Server=CNZGNCDSL-T580\SQLEXPRESS;"
                      "Database=KriptoDB;"
                      "Trusted_Connection=yes;")

 cursor = conn.cursor()
 cursor.execute("SELECT KriptoName FROM KriptoDB.dbo.KriptoTrades")
 symbolDohvat = cursor.fetchall()
 for row in symbolDohvat:
  for coin in row:
    if coin == x['slug']:
       NapuniBazu(x['cmc_rank'],x['symbol'],x['slug'],x["quote"]["USD"]["price"],x["quote"]["USD"]["percent_change_1h"],x["quote"]["USD"]["percent_change_24h"],x["quote"]["USD"]["percent_change_7d"])
      #print(" ",'{:<6.0f}'.format(x['cmc_rank']),'{:<9s}'.format(x['symbol']),'{:<18s}'.format(x['slug']),'{:>15.3f}'.format(float(x["quote"]["USD"]["price"])),'{:>14.2f}'.format(float(x["quote"]["USD"]["percent_change_1h"])),"%",'{:>15.2f}'.format(float(x["quote"]["USD"]["percent_change_24h"])),"%",'{:>17.2f}'.format(float(x["quote"]["USD"]["percent_change_7d"])),"%")


print()
print(dash)
print('{:>45s}'.format(" Kripto BOT - PUNJENJE BAZE "), "  END:", datetime.datetime.now())
print(dash)
print(dash)



