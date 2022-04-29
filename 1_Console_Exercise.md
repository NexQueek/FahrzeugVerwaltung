### Aufgabe 1) 
Die erste Aufgabe soll sich mit der Installierung der Entwicklungsumgebung beschäftigen.

 - Schritt 1: Visual Studio 2022 installieren.
 - Schritt 2: Dieses Projekt in Visual Studio 2022 klonen.
 - Schritt 3: Gebe "Hello World" auf der Konsole aus.
### Aufgabe 2)
 Erstelle die Klasse **Vehicle**  mit folgenden Eigenschaften

|Name|Datentyp  |
|--|--|
|Ident| int |
|Brand| string |
|Model| string |

Nun soll der Anwender die Möglichkeit habe, die Eigenschaften über die Konsole einzugeben
Das Menü soll wie folgt aussehen:

    Hallo und herzlich willkommen!
    Bitten wählen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle löschen 
    3) Alle Vehicle anzeigen
    10) Programm beenden
    >1
    Bitten Geben sie nun die Id ein
    >1
    Bitten Geben sie nun die Marke ein
    >VW
    Bitten Geben sie nun das Modell ein
    >Caddy
    Fahrzeug wurde angelegt
    
    Bitten wählen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle löschen 
    3) Alle Vehicle anzeigen
    10) Programm beenden
    >3 
    Ident: 1, Marke: VW, Modell:Caddy
    
Nun soll der User die Eigenschaft **Ident** nicht mehr selber setzen können, sondern sie soll vom System automatisch gesetzt werden. 
**Wichtig:** Jede Ident sollte nur einmal gesetzt werden dürfen => keine Duplikate
### Aufgabe 3) Bearbeiten eines Vehicles
Es soll nun dem Nutzer ermöglich werden bestimmte Vehicle zu bearbeiten 
```
Bitten wählen Sie die Aktion 
    Bitten wählen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle löschen
    3) Alle Vehicle anzeigen 
    4) Vehicle bearbeiten
    10) Programm beenden
    >4
    Geben Sie bitte nun den Ident ein
    >1
    Bitten Geben sie nun die Marke ein
    >BMW
    Bitten Geben sie nun das Modell ein
    >3er
    Fahrzeug mit dem Ident 1 wurde bearbeitet
```
### Aufgabe 4) Exceptionhandling
Sollten falsche Eingaben getätigt werden, darf das Programm nicht abstürzen.
Der User soll darauf

### Aufgabe 5) Erstellung  des VehicleService

Erstellen sie die Klasse **VehicleConsoleService** in dem Projekt **FahrzeugVerwaltung.Service**
Der **VehicleConsoleService** soll nun 4 Methoden bekommen


 - `public void Save(){...}` //Soll ein Vehicle hinzufügen können
 - `public void Delete(){...}` // Soll ein Vehicle löschen können
 - `public void Update(){...}`//Soll ein Vehicle editieren können
 - `public void GetAll(){}` //Soll alle Vehicle anzeigen


Nun soll die alte Logik auf diese 4 Methoden extrahiert werden
Außerdem soll die Klasse eine private Feld (auch Field genannt) bekommen 

|Name| Datentyp  |
|--|--|
| vehicleList | List\<Vehicle\> |


### Aufgabe 6) Vererbung
Es soll nun 2 Spezialisierungen von einem Vehicle geben. 
Erstelle die Klasse **PKW** und **LKW**. Beiden **erben** von Vehicle.
Die Klasse LKW soll nun eine weitere Eigenschaft bekommen
|Name|Datentyp  |Erklärung
|--|--|--|
| Capacity | double  |Gibt die Frachtkapazität an

Nun soll der Anwender beim Erstellen eines Vehicles gefragt ob es 1) ein PKW oder 2) LKW ist



    Bitten wählen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle löschen
    3) Alle Vehicle anzeigen 
    4) Vehicle bearbeiten
    10) Programm beenden
    >1
    Welchen Typ wollen Sie anlegen 
    1)PKW
    2)LKW
    >2
    Bitte geben Sie die Frachtkapazität in kg an
    >4500
    Bitten Geben sie nun das Marke ein
    >MAN
    Bitten Geben sie nun das Modell ein
    >Sattelzug
    Ein LKW wurde erstellt
    
   
### Aufgabe 7) Abstraktion
In dieser Aufgabe soll der Anwender nicht mehr eine Instanz von der Klasse **Vehicle** erstellen können. Es soll entweder ein PKW oder ein LKW erstellt werden.
(Keyword: abstract)

### Aufgabe 8) Speichern der vehicle Liste
Erweitern des Menüs um *5) Speichern* 
Die Eingaben sollen nun in einer JSON Datei gespeichert werden, dafür soll die JsonConvert Klasse genutzt werden. 
Die Datei soll unter C:/dev/vehicles.json gespeichert werden

### Aufgabe 9) Laden der Liste 
Bei dem Start des Programmes soll geprüft werden, ob unter C:/dev die Datei vehicles.json verfügbar ist. Wenn die Datei verfügbar ist sollen die Vehicles in der Konsole angezigt werden. Ansonsten soll eine leere Liste erstellt werden.  

### Aufgabe 10) Speichern erweitern.

Sobald der User speichert drcükt soll er der Namen der Datei angeben.

### Aufgabe 11) Laden erweitern. 
Das Programm soll beim start alle json Datein unter C:/dev auflisten. Der Nutzer soll über Zahleneingaben, die Liste auswählen die er bearbeiten kann.


