Hier is een lesontwerp van ongeveer 1 uur in de vorm van een oefening voor teams van 2 tot 6 studenten om hen te leren hoe je een branch in GitHub kunt beveiligen. Het is gericht op beginnende developers die al ervaring hebben met Git, GitHub, branches en pull-requests.

---

### **Lesdoel**
Aan het einde van deze les zijn studenten in staat om:
1. Branch-beveiligingsregels in te stellen in een GitHub-repository.
2. Begrijpen waarom branch-beveiliging belangrijk is in teamprojecten.
3. Een proces te volgen waarin code gecontroleerd wordt voordat deze samengevoegd wordt.

---

### **Benodigdheden**
1. Toegang tot GitHub (teamleden moeten een account hebben).
2. Een GitHub-repository die door het team kan worden gebruikt (of een nieuwe repository aangemaakt door de instructeur).
3. Laptops of computers met internettoegang.

---

### **Voorbereiding door de Instructeur**
1. Maak een openbare GitHub-repository en voeg de studenten als "collaborators" toe, of laat hen dit zelf doen als onderdeel van de les.
2. Zorg dat de repository ten minste één branch heeft naast de `main`-branch (bijvoorbeeld `dev`).

---

### **Lesstructuur**

#### **Inleiding (10 minuten)**
- **Doel en belang:** 
  - Leg kort uit wat branch-beveiliging is en waarom het belangrijk is in een teamomgeving. 
  - Voorbeelden: voorkomen van directe pushes naar `main`, het afdwingen van code reviews, en het behouden van een stabiele codebasis.
- **Uitleg:** 
  - Vertel wat de oefening inhoudt: het instellen van branch-beveiliging en het simuleren van het gebruik ervan.

---

#### **Oefening (40 minuten)**

**Stap 1: Teams vormen en taken verdelen (5 minuten)**
- Verdeel de studenten in teams van 2-6 personen.
- Rollen:
  - **Beheerder(s):** Een of twee studenten die de repository-instellingen mogen aanpassen.
  - **Ontwikkelaars:** De rest van het team zal werken aan pull-requests en proberen branches te beveiligen.

**Stap 2: Simuleer een ontwikkelomgeving (10 minuten)**
1. **Maak een nieuwe branch aan:** Elk teamlid maakt een eigen feature-branch, bijvoorbeeld `feature/username`.
2. **Wijzigingen aanbrengen:** Elk teamlid voegt een eenvoudige wijziging toe, zoals een extra regel tekst in een README-bestand of een nieuw bestand.

**Stap 3: Branch-beveiliging instellen (15 minuten)**
1. **Beheerderstaak:**
   - Ga naar de instellingen van de repository → "Branches" → "Add rule".
   - Stel de volgende beveiligingsregels in voor de `main`-branch:
     - Vereis pull-requests voor wijzigingen.
     - Vereis goedkeuring van minimaal één reviewer.
     - Optioneel: Schakel "Require status checks" in als een CI-pipeline beschikbaar is.
   - Deel de beveiligingsregels met het team.
2. **Teamtaken:**
   - Teamleden proberen wijzigingen direct naar `main` te pushen (dit zou moeten falen).
   - Teamleden maken pull-requests aan vanuit hun feature-branches en vragen elkaar om reviews.
   - Teamleden reviewen en keuren elkaars pull-requests goed.
   - Na goedkeuring mag de code worden gemerged naar `main`.

**Stap 4: Reflectie en uitdagingen (10 minuten)**
- Laat elk team reflecteren:
  - Wat hebben ze geleerd over branch-beveiliging?
  - Zijn er situaties waarin beveiliging hen heeft geholpen?
- Uitdagingen:
  - Vraag teams om aanvullende regels in te stellen, zoals het beperken van wie naar de branch mag pushen of het vereisen van meerdere reviewers.
  - Laat studenten experimenteren met het inschakelen van extra beveiligingsopties (zoals "Include administrators").

---

#### **Afronding (10 minuten)**
- Bespreek als groep de volgende vragen:
  - Waarom is het belangrijk om beveiligingsregels in te stellen?
  - Wat zijn mogelijke valkuilen als je geen branch-beveiliging gebruikt?
- Laat teams hun bevindingen delen.

---

### **Aanvullende Opties**
- **Uitbreiding:** Laat teams experimenteren met geautomatiseerde tools zoals GitHub Actions om extra checks aan pull-requests toe te voegen.
- **Toepassing:** Geef de opdracht om een echte projectrepository op dezelfde manier te beveiligen.

---

Deze interactieve oefening combineert leren door doen met teamwork en laat studenten de praktische voordelen van branch-beveiliging ervaren.