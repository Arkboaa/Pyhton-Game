import UnityEngine
import PlayerController


def ilerle(miktar):
    UnityEngine.GameObject.Find("Player").GetComponent[PlayerController]().move(miktar)

def zipla():
    UnityEngine.GameObject.Find("Player").GetComponent[PlayerController]().jump()