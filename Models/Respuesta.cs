public class Respuesta{
    public int IdRespuesta {get; set;}
    public int IdPregunta {get; set;}
    public int Opcion {get; set;}
    public string Contenido {get; set;}
    public bool Correcta {get; set;}

    public Respuesta(){}
    public Respuesta(int idR, int idP, int opc, string cont, bool correcta){
        IdRespuesta = idR;
        IdPregunta = idP;
        Opcion = opc;
        Contenido = cont;
        Correcta = correcta;
    }
}