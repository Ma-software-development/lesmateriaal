# Werken met Github en Unity

<img src="images/gitAndUnity.png">

## gitignore

### wat is gitignore?

Wanneer je met Git werkt, houdt Git normaal gesproken alle veranderingen bij in je project. Maar sommige bestanden wil je niet in je repository opnemen, bijvoorbeeld:

Tijdelijke bestanden van je editor (zoals .vscode/ of .idea/)

Build- of compilatiebestanden (zoals /dist, /build)

Logbestanden (*.log)

Gevoelige gegevens (zoals config.env of api_keys.json)

Daarom gebruik je een .gitignore om die bestanden automatisch buiten Git te houden.

### voorbeeld van een .gitignore

```` bash
# de hashtag wordt gebruikt als opmerking dus niet uitgevoerd

# een bestand negeren
plaatje.psd

# een directory negeren
graphics/

````

# 🚀 Unity-project publiceren naar GitHub

Een stap-voor-stap handleiding om jouw Unity-project veilig te publiceren op GitHub.

---

## 🧩 Stap 1 – Nieuwe repository aanmaken op GitHub

1. Ga naar [https://github.com/new](https://github.com/new)
2. Vul de velden in:
   - **Repository name:** `MijnUnityProject`
   - **Visibility:** `Public`
   - ✅ **Add a README file**
   - ✅ **Add .gitignore** → selecteer **Unity**
3. Klik op **Create repository**
4. Kopieer de **HTTPS-URL** van jouw repository  
   👉 Voorbeeld:  
   ```
   https://github.com/jouwgebruikersnaam/MijnUnityProject.git
   ```

---

## 🎮 Stap 2 – Unity-project openen op jouw computer

1. Open **Unity Hub**
2. Zoek het project dat je wil uploaden
3. Klik op de **drie puntjes (⋮)** rechts van de projectnaam → kies **Show in Explorer**
4. Klik op de **projectmap** om deze te openen
5. Klik met de **rechtermuisknop** in de map en kies  
   👉 **Open in Terminal**

---

## 💻 Stap 3 – Git instellen en koppelen aan GitHub

Open nu de terminal in de projectmap en voer onderstaande commando’s uit:

---

### 🔹 Controleer of Git nog niet is ingesteld
```bash
git status
```
➡️ Verwachte melding:  
```
fatal: not a git repository (or any of the parent directories): .git
```

---

### 🔹 Maak een nieuwe lokale repository
```bash
git init
```

---

### 🔹 Controleer de status opnieuw
```bash
git status
```

---

### 🔹 Zorg dat de branch `main` heet
```bash
git branch -M main
```

---

### 🔹 Koppel met jouw online repository
> Vervang de URL hieronder door de URL die je van GitHub kopieerde.
```bash
git remote add origin https://github.com/jouwgebruikersnaam/MijnUnityProject.git
```

---

### 🔹 Haal de README.md en .gitignore binnen
```bash
git pull origin main
```

---

### 🔹 Controleer opnieuw de status
```bash
git status
```

---

### 🔹 Voeg alle bestanden toe aan de "stage"
```bash
git add .
```

---

### 🔹 Maak een commit met een duidelijke boodschap
```bash
git commit -m "feat(main): project added"
```

---

### 🔹 Push alles naar GitHub
```bash
git push -u origin main
```

---

## ✅ Stap 4 – Controleer je repository

1. Ga terug naar jouw repository op GitHub  
2. Vernieuw de pagina (`F5`)  
3. Controleer of al je Unity-bestanden zichtbaar zijn

---

### 🎉 bijna Klaar!
Je Unity-project is nu succesvol gepubliceerd op GitHub.  
Vanaf nu kun je verder werken met:
- `git add .` → om nieuwe wijzigingen toe te voegen  
- `git commit -m "beschrijving"` → om op te slaan  
- `git push` → om te uploaden naar GitHub

---

### workflow
Verander iets in jouw Unityproject en update jouw remote repository op unity. 

Zorg dat je op jouw remote repo 3 of meer commits hebt

## Copieer de url van jouw online repository van een unityproject en lever deze in bij simulise 
---

### 🎉 Bijna Klaar!


Nu nog een GIF aan de README toevoegen.


Open jouw Unity-bestand, zet het in playmode en maak een schermopname. Maak in de map waar jouw README.md staat met als naam **images** en bewaar jouw opname in GIF-formaat in deze map

voeg in jouw README.md deze schermopname toe

![alt tekst opname](url van jouw opname)

Plaats deze update in jouw lokale repository en push jouw lokale repository naar github!