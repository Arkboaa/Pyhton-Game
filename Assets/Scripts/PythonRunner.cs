using UnityEngine;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor.Scripting.Python;
#endif

public class PythonRunnerScript : MonoBehaviour
{
    public TMP_InputField kodGirisAlani;
    public TextMeshProUGUI hataMesajText;
    public PlayerController oyuncu;

    public void PythonKodunuCalistir()
    {
        hataMesajText.text = "";
        string playerInput = kodGirisAlani.text;

        
        string wrapper = @"
import UnityEngine
def ilerle(x): UnityEngine.GameObject.Find('Player').GetComponent('PlayerController').move(x)
def zipla(): UnityEngine.GameObject.Find('Player').GetComponent('PlayerController').jump()
def renk_bak(): return UnityEngine.GameObject.Find('Player').GetComponent('PlayerController').NesneRenginiOku()
";

        string fullCode = wrapper + "\n" + playerInput;

        try
        {
#if UNITY_EDITOR
            PythonRunner.RunString(fullCode);
            hataMesajText.color = Color.green;
            hataMesajText.text = "Kod baþarýyla çalýþtý!";
#endif
        }
        catch (Exception e)
        {
            hataMesajText.color = Color.red;
            hataMesajText.text = "Hata: " + e.Message;
        }
    }
}