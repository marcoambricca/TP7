public class Pregunta{
    public int IdPregunta {get; set;}
    public int IdCategoria {get; set;}
    public int IdDificultad {get; set;}
    public string Enunciado {get; set;}
    public string Foto {get; set;}

    public Pregunta(){}
    public Pregunta(int idP, int idC, int idD, string enunciado, string foto){
        IdPregunta = idP;
        IdCategoria = idC;
        IdDificultad = idD;
        Enunciado = enunciado;
        Foto = foto;
    }
}