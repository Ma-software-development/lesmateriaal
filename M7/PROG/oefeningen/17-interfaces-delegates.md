# Oefening: Interfaces & Delegates

## Leerdoel

Interfaces en delegates combineren voor flexibele, ontkoppelde systemen.

---

## Oefening 1: Interface — IInteractable

Maak een interactie-systeem waar de speler E drukt bij objecten:

```csharp
public interface IInteractable
{
    string InteractionText { get; }
    void Interact();
}
```

Maak twee implementaties:

```csharp
public class TreasureChest : MonoBehaviour, IInteractable
{
    public string InteractionText => "Open kist";
    private bool isOpened = false;

    public void Interact()
    {
        if (!isOpened)
        {
            isOpened = true;
            Debug.Log("Kist geopend! Je vindt 50 goud.");
            // TODO: Verander sprite of kleur
        }
    }
}

public class NPC : MonoBehaviour, IInteractable
{
    public string InteractionText => "Praat met NPC";

    public void Interact()
    {
        Debug.Log("NPC: Hallo avonturier!");
        // TODO: Toon dialoog
    }
}
```

De speler checkt wat er in de buurt is:

```csharp
public class PlayerInteraction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // TODO: Gebruik Physics2D.OverlapCircle om nearby objects te vinden
            // TODO: Check of ze IInteractable implementeren
            // TODO: Roep Interact() aan
        }
    }
}
```

---

## Oefening 2: Delegate — Custom Callback

Maak een timer die een callback uitvoert bij voltooiing:

```csharp
using System;

public class CallbackTimer : MonoBehaviour
{
    public void StartTimer(float duration, Action onComplete)
    {
        StartCoroutine(TimerRoutine(duration, onComplete));
    }

    IEnumerator TimerRoutine(float duration, Action onComplete)
    {
        yield return new WaitForSeconds(duration);
        onComplete?.Invoke();
    }
}
```

Gebruik het:

```csharp
public class TimerTest : MonoBehaviour
{
    public CallbackTimer timer;

    void Start()
    {
        // TODO: Start timer van 3 seconden
        // Callback: print "Timer afgelopen!"
        timer.StartTimer(3f, () => {
            Debug.Log("Timer afgelopen!");
        });

        // TODO: Start nog een timer van 5 seconden met andere callback
    }
}
```

**Test:** Na 3 seconden verschijnt het eerste bericht, na 5 het tweede.
