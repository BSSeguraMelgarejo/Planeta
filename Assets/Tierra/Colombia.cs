using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colombia : MonoBehaviour
{
    public float force = 2; //variable para el salto de "ubicaci�n"

    public bool mFaded = false; //bandera para el fade-in y fade-out

    public float Duration = 0.2f; //variable de tiempo de transici�n

    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
    public void Update()
    {
        Text miPais = GameObject.Find("miPais").GetComponent<Text>();//encontrar el "text Legacy" para cambiarlo m�s adelante
        Text miDescripcion = GameObject.Find("miDescripcion").GetComponent<Text>();
        Image miImagen = GameObject.Find("miImagen").GetComponent<Image>();
        Rigidbody locacion = GameObject.Find("locacion").GetComponent<Rigidbody>();


        if (Input.GetMouseButtonDown(0)) //Cada vez que se haga clic (izquierdo)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Captar el punto a donde est� viendo la c�mara

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform != null)
                {
                    imprimirColombia(hit.transform.gameObject);

                    Rigidbody rb;

                    if(rb = hit.transform.GetComponent<Rigidbody>()) // esta es asignaci�n Y TAMB��N VERIFICA SI ES NULL O NO
                    {
                        //Asigna al cuerpo r�gido, el nombre del componente al que se le hizo clic
                        //Fade();
                        salto(rb);// Luego se hace saltar

                        if(hit.transform.GetComponent<Rigidbody>().name == "locacion")
                        {
                        miPais.text = "Colombia"; //cambiar el nombre a "Colombia"
                        miDescripcion.text = "Colombia es un pa�s del extremo norte de Sudam�rica. Su paisaje cuenta con bosques tropicales, las monta�as de los Andes y varias plantaciones de caf�.";
                        miImagen.sprite = Resources.Load<Sprite>("imagenColombia2");
                        }

                        else if (hit.transform.GetComponent<Rigidbody>().name == "locacion (1)"){
                            miPais.text = "Brasil";
                            miDescripcion.text = "Brasil es un vasto pa�s de Sudam�rica que se extiende desde la Cuenca del Amazonas en el norte hasta los vi�edos y las enormes cataratas del Iguaz� en el sur. R�o de Janeiro, simbolizado por su estatua de 38 m del Cristo Redentor sobre el cerro del Corcovado";
                            miImagen.sprite = Resources.Load<Sprite>("imagenBrasil");
                        }

                        else if (hit.transform.GetComponent<Rigidbody>().name == "locacion (2)")
                        {
                            miPais.text = "China";
                            miDescripcion.text = "China es un pa�s soberano de Asia Oriental. Es el pa�s m�s poblado del mundo, con m�s de 1400 millones de habitantes, y la primera potencia econ�mica mundial por PIB en t�rminos de paridad de poder adquisitivo.";
                            miImagen.sprite = Resources.Load<Sprite>("imagenChina");
                        }

                        //Fade();
                    }
                }
            }
        }
        
    }

    public void imprimirColombia (GameObject go) //para estar seguros de que est� entrando al if del clic
    {
        print(go.name);
    }

    public void salto(Rigidbody rig) //para la animaci�n de "ubicaci�n"
    {
        rig.AddForce(rig.transform.up * force, ForceMode.Impulse); //lanzar con la fuerza que se asign� a la variable de m�s arriba
    }

    public void Fade() //m�todo para hacer el efecto de disolver
    {
        var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0)); //Llamar el m�todo de la animaci�n con el canvGroup, desde el alpha (como est�, ya sea 100% o 0%) hasta el que corresponda
        mFaded = !mFaded; //alternar el mFaded
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end) //m�todo para reproducir la animaci�n
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration); //setear el alfa de canvGroup 

            yield return null;//Como en todos los m�todos que se llaman en co-rutinas
        }
    }

}
