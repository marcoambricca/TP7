public class Dificultad{
    public int IdDificultad {get; set;}
    public string Nombre {get; set;}

    public Dificultad(){}
    public Dificultad(int id, string nombre){
        IdDificultad = id;
        Nombre = nombre;
    }
}