using System.Data.SqlClient;
using Dapper;

public static class BD{
    private static string ConnectionString {get; set;} = @"Server=localhost;DataBase=PreguntadORT;Trusted_Connection=True;";

    public static List<Categoria> ObtenerCategorias(){
        List<Categoria> user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Categorias";
            user = db.Query<Categoria>(sql).ToList();
        }
        return user;
    }
    public static List<Dificultad> ObtenerDificultades(){
        List<Dificultad> user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Dificultades";
            user = db.Query<Dificultad>(sql).ToList();                                                              
        }
        return user;
    }
    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria){
        List<Pregunta> user = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            if (dificultad > -1 && categoria > -1){
                string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @Dificultad AND IdCategoria = @Categoria";
                user = db.Query<Pregunta>(sql, new {Dificultad = dificultad, Categoria = categoria}).ToList();
            }
            else if (dificultad == -1 && categoria>-1){
                string sql = "SELECT * FROM Preguntas WHERE IdCategoria = Categoria";
                user = db.Query<Pregunta>(sql, new {Categoria = categoria}).ToList();
            }
            else if (categoria == -1 && dificultad>-1){
                string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @Dificultad";
                user = db.Query<Pregunta>(sql, new {Dificultad = dificultad}).ToList();
            }
            else{
                string sql = "SELECT * FROM Preguntas";
                user = db.Query<Pregunta>(sql).ToList(); 
            }
        }
        return user;
    }
    
    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas){
        List<Respuesta> user = new List<Respuesta>();
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            for(int i = 0; i<preguntas.Count; i++){
                string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @idpregunta";
                int preg=preguntas[i].IdPregunta;
                user.AddRange(db.Query<Respuesta>(sql, new{idpregunta = preg}).ToList());
            }
        }
        return user;
    }
}