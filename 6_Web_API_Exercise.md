
# 🚗 Übungsaufgabe: Fahrzeugverwaltungs-API in C# & ASP.Net Core

## 🎯 Ziel
Entwickle eine Anwendung zur Verwaltung von Fahrzeugen, bei der später auch Werkstattaufträge zu einzelnen Fahrzeugen angelegt werden können. Die Übung dient der praktischen Anwendung von C#-Grundlagen, OOP, Controllern und ggf. WebAPI-Strukturen.

---

## 🧱 Projektstruktur & Meilensteine

### 🔹 Meilenstein 1: Projektsetup & Datenmodellierung

**Aufgaben:**
- Neues C#-Projekt erstellen (ASP.NET Core WebAPI).
- Klasse `Fahrzeug` anlegen mit folgenden Eigenschaften:
  - `int ID`
  - `string Hersteller`
  - `string Modell`
  - `int Baujahr`
  - `string Kennzeichen`
- Verwende zur Speicherung eine Liste (`List<Fahrzeug>`) oder ein In-Memory-Repository.

---

### 🔹 Meilenstein 2: Fahrzeugverwaltung (CRUD)

**Ziel:** Erstellung eines Controllers zur Verwaltung von Fahrzeugen.

**Aufgaben:**
- Controller `FahrzeugController` mit folgenden Endpunkten:

| Methode | Route                     | Beschreibung                  |
|--------|---------------------------|-------------------------------|
| GET    | `/fahrzeuge`              | Alle Fahrzeuge abrufen        |
| GET    | `/fahrzeuge/{id}`         | Einzelnes Fahrzeug anzeigen   |
| POST   | `/fahrzeuge`              | Neues Fahrzeug anlegen        |
| PUT    | `/fahrzeuge/{id}`         | Fahrzeugdaten aktualisieren   |
| DELETE | `/fahrzeuge/{id}`         | Fahrzeug löschen              |

- Teste die Schnittstellen mit Swagger, Postman oder einfacher Konsolenausgabe.

---

### 🔹 Meilenstein 3: Modellierung von Werkstattaufträgen

**Ziel:** Vorbereitung auf erweiterte Funktionalität durch Modellierung von Werkstattaufträgen.

**Aufgaben:**
- Neue Klasse `Werkstattauftrag`:

  ```csharp
  public class Werkstattauftrag
  {
      public int ID { get; set; }
      public int FahrzeugID { get; set; }
      public string Beschreibung { get; set; }
      public DateTime Datum { get; set; }
      public AuftragsStatus Status { get; set; }
  }

  public enum AuftragsStatus
  {
      Offen,
      InBearbeitung,
      Abgeschlossen
  }
  ```

- Verknüpfe Aufträge mit Fahrzeugen über `FahrzeugID`.

---

### 🔹 Meilenstein 4: Werkstattaufträge verwalten

**Ziel:** CRUD-Funktionalität für Werkstattaufträge implementieren.

**Aufgaben:**
- Erstelle `WerkstattauftragController` mit folgenden Endpunkten:

| Methode | Route                                          | Beschreibung                          |
|--------|------------------------------------------------|---------------------------------------|
| GET    | `/auftraege`                                   | Alle Aufträge anzeigen                |
| GET    | `/fahrzeuge/{fahrzeugId}/auftraege`            | Aufträge zu einem Fahrzeug anzeigen   |
| POST   | `/fahrzeuge/{fahrzeugId}/auftraege`            | Auftrag zu einem Fahrzeug anlegen     |
| PUT    | `/auftraege/{id}`                              | Auftrag aktualisieren                 |
| DELETE | `/auftraege/{id}`                              | Auftrag löschen                       |

- Optional: Sortierung nach Datum oder Filter nach Status.

---
