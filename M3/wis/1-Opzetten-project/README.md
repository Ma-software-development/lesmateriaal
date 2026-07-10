## **Instructie: Start een nieuw 2D-project in Unity**  
### **Projectnaam:** M3-skill  
### **Doel:** Een Unity 2D-project opzetten met een repository voor versiebeheer en controle door de docent.  

---

### **Stap 1: Unity 2D-project aanmaken**  
1. Open **Unity Hub** en klik op **"Nieuw project"**.  
2. Kies als template **2D (Core)**.  
3. Geef het project de naam: **M3-skill**.  
4. Kies een locatie **buiten OneDrive** (bijvoorbeeld: `C:\UnityProjects\M3-skill\`).  
5. Klik op **"Maak aan"** om het project te genereren.  

---

### **Stap 2: Git Repository opzetten en delen**  
1. **Git installeren** (indien nog niet gedaan):  
   - Download en installeer Git vanaf: [https://git-scm.com/](https://git-scm.com/).  
2. **GitHub-account aanmaken** (indien nog niet gedaan).  
3. **Repository aanmaken in GitHub:**  
   - Ga naar [https://github.com/](https://github.com/) en log in.  
   - Klik op **"New repository"**.  
   - Geef de repository de naam: **M3-skill**.  
   - Zet deze **op privé** en voeg een `.gitignore` toe voor Unity.  
   - Klik op **"Create repository"**.  
4. **Repository koppelen via de Command Prompt:**  
   - Open de **Command Prompt** (**cmd**) in Windows.  
   - Navigeer naar de projectmap door het volgende commando uit te voeren:  
     ```cmd
     cd C:\UnityProjects\M3-skill
     ```
   - Voer vervolgens de volgende commando’s uit om het project te koppelen aan de repository:  
     ```cmd
     git init
     git remote add origin https://github.com/jouw-gebruikersnaam/M3-skill.git
     git pull origin main
     git add .
     git commit -m "Eerste commit - project setup"
     git push -u origin main
     ```
5. **Docent toevoegen als collaborator:**  
   - Ga in GitHub naar de repository-instellingen.  
   - Klik op **"Manage access"** > **"Invite a collaborator"**.  
   - Voeg **djsjollema** toe

---

### **Stap 3: Projectstructuur inrichten**  
1. Open Unity en ga naar de **Project**-view.  
2. Maak de volgende mappen aan in de **Assets**-map:  
   - **Scenes** (voor alle opdrachten)  
   - **Sprites** (voor afbeeldingen)  
   - **Scripts** (voor C#-scripts)  
   - **Audio** (voor geluidseffecten/muziek)  
   - **Prefabs** (voor herbruikbare objecten)  

---

### **Stap 4: Scenes voor opdrachten maken**
Alle opdrachten moeten worden uitgevoerd in een aparte scene met als naam van de scene de naam van de opdracht. De eerste opdracht heet Bit.
1. Ga naar de map **Scenes**.  
2. Maak de eerste Scene aan per 
   - **Bit.unity**  

---

### **Stap 5: Eerste push naar GitHub via de Command Prompt**  
1. Open **Command Prompt** (**cmd**) en voer uit:  
   ```cmd
   cd C:\UnityProjects\M3-skill
   git add .
   git commit -m "Projectstructuur aangemaakt"
   git push
   ```
2. Controleer in GitHub of de bestanden correct zijn geüpload.  

---

### **Stap 6: Unity instellen voor versiebeheer**  
1. Ga in Unity naar **Edit** > **Project Settings**.  
2. Ga naar **Editor** en stel **Version Control Mode** in op **Visible Meta Files**.  
3. Ga naar **Asset Serialization** en zet dit op **Force Text**.  
4. Sla de instellingen op.  

---

### **Stap 7: Controle door de docent**  
- Zorg ervoor dat de docent toegang heeft tot de repository.  
- Push regelmatig updates via Git.  
- De docent kan de commits controleren en feedback geven.  

---

✅ **Je Unity 2D-project is nu correct opgezet met versiebeheer!**

## ps moet git-repository in de unity-folder, of kun je beter een git repository maken met daarin een map met een unity project?

Het is meestal beter om **de Git-repository in de hoofdmap van het Unity-project** te plaatsen, oftewel: de Git-repository in de map van het Unity-project te zetten. Dit heeft de volgende voordelen:

### **Aanbevolen structuur:**
```
/MyUnityProject/  <-- Dit is de Git-repository
  |-- Assets/
  |-- Packages/
  |-- ProjectSettings/
  |-- .git/
  |-- .gitignore
```

### **Voordelen van deze aanpak:**
1. **Eenvoudige versiebeheer**  
   - Unity’s standaard projectstructuur wordt goed ondersteund door Git.
   - Je kunt direct je `.gitignore` instellen op basis van Unity’s aanbevolen lijst om onnodige bestanden uit Git te houden.

2. **Minder complexe paden**  
   - Als je een aparte map voor de repository maakt en daarbinnen Unity zet, kan het onnodig complexe paden en configuraties opleveren.

3. **Minder risico op per ongeluk bestanden buiten het project op te slaan**  
   - Als je de Git-repository in een bovenliggende map plaatst, bestaat de kans dat je per ongeluk bestanden commit die niet bij het Unity-project horen.

4. **Beter samenwerken met andere tools**  
   - CI/CD-tools, Unity Collaborate en andere Unity-integraties werken beter als je het project in de root van de repository hebt.

### **Wanneer een andere aanpak nuttig kan zijn?**
De enige situatie waarin je de repository boven het Unity-project zou kunnen plaatsen, is als je meerdere projecten binnen dezelfde repo beheert. Dan krijg je bijvoorbeeld zoiets als:

```
/MyGitRepo/
  |-- UnityProject1/
  |-- UnityProject2/
  |-- README.md
  |-- .gitignore
  |-- .git/
```

Maar als je alleen één Unity-project hebt, is het veel handiger om de repo **direct in de Unity-projectmap** te zetten.

Wil je nog een `.gitignore`-bestand voor Unity? Dan kan ik er een genereren! 🚀