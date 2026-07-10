# Les 02 – Command Line Interface

## Wat is een CLI?

CLI staat voor **Command Line Interface**, een tekstgebaseerde interface voor interactie met het besturingssysteem.

## Overzicht

* CLI
* Directories
* Werken met directories
* Programma’s en bestanden
* Van CLI naar GUI en vice versa
* Samenvatting

## Verschillen GUI vs CLI

* **GUI (Graphical User Interface)**: voor gebruikers.
* **CLI (Command Line Interface)**: voor developers/IT.

## Omgeving

* Desktop: Terminal of Server.

## Een Command Line Interface openen

### Windows

1. Klik linksonder met de muis.
2. Typ `command prompt`.
3. Klik op de Command Prompt-app.

### macOS

1. Open Spotlight (klik op het vergrootglas).
2. Typ `terminal`.
3. Klik op Terminal.app.

## Directories (mappen, folders)

Een directory is een doosje met een naam, georganiseerd als een boomstructuur:

* Windows: `C:\` (root, per drive).
* Linux/macOS: `/` (root, per drive).

## Huidige Directory (CWD)

* De actieve directory is de **Current Working Directory (CWD)**.
* Op Windows start je in `C:\Users\<jouw gebruikersnaam>`.
* Gebruik `dir` (Windows) of `ls` (Linux/macOS) om de inhoud te tonen.

## Bestanden filteren met joker (\*)

Bij `dir` of `ls` kun je wildcards gebruiken, bijvoorbeeld:

```sh
# Windows
dir *.txt    # alle .txt-bestanden
# Linux/macOS
ls a*          # alle bestanden die beginnen met 'a'
```

## cd: Change Directory

* `cd <directory>`: verandert de CWD naar `<directory>`.
* Speciale namen:

  * `.`: huidige directory.
  * `..`: parent directory.
  * `/` of `C:\`: root.
  * `~` (Linux/macOS): home directory.

```sh
cd documents   # naar 'documents'
cd ..          # één niveau omhoog
cd /           # naar de root
cd ~           # naar je home directory (Linux/macOS)
```

## mkdir: Make Directory

```sh
mkdir newDirectory
```

## rmdir / rm: Remove Directory

### Windows

```sh
rmdir newDirectory      # leeg directory
rmdir /s newDirectory   # directory met inhoud
```

### Linux/macOS

```sh
rm newDirectory       # waarschuwt bij bestanden
rm -rf newDirectory   # force remove, inclusief inhoud
```

## Verwerkingsopdracht

1. Maak in je home directory een subdirectory `m1` en maak deze je CWD.
2. Maak in `m1` de volgende boomstructuur:

   ```
   m1skil-github/
   ├── les1/
   └── les2/
   ```
3. Test de opdrachten in de map `m1`.

## Programma’s en bestanden

* `notepad test.txt`: opent Notepad en vraagt om een nieuw bestand aan te maken.
* `type test.txt` (Windows) of `cat test.txt` (Linux/macOS) toont de inhoud.
* macOS: `touch test.txt` en `open -a TextEdit test.txt`.

## Extensies & verborgen bestanden tonen (Windows)

1. Open Verkenner.
2. Klik op **View**.
3. Vink **File name extensions** en **Hidden items** aan.

## Programma openen via CLI

* Navigeer naar de map, bijv. `cd m1\skill\les01\`.
* Typ de programmanaam, bijv. `notepad`.

## Van CLI naar GUI en vice versa

* **CLI naar GUI**:

  * Windows: `explorer .`
  * macOS: `open .`
* **GUI naar CLI**:

  * Typ `cmd` in de adresbalk van Verkenner (Windows).

## Samenvatting

* `cmd`: open CLI.
* `dir` / `ls`: toon inhoud.
* `mkdir`: maak map.
* `cd`: verander map.
* `rmdir` / `rm`: verwijder map.
* `notepad [bestandsnaam]`: open Notepad.
* `explorer .`: open GUI in CWD.
* Belangrijke directory namen:

  * `.`: huidige directory.
  * `..`: hoger niveau.
  * `~`: home directory (Linux/macOS).

## opdracht
* breid met behulp van de Commandprompt in de terminal in de map m1skill-github uit met de mappen les3 tot en met les 8
* gebruik het commando `tree` om een overzicht te maken van jouw directory
* maak een screenshot van deze `tree` en bewaar deze als een .png afbeelding
* stuur deze afbeelding naar simulise en wacht tot de docent jouw werk gecontroleerd heeft
