public static class Juego{
    private static string _username {get;set;}
    private static int _puntajeActual {get;set;}
    private static int _cantidadPreguntasCorrectas {get;set;}
    public static int preguntasCont {get; set;}
    private static List<Pregunta> _preguntas {get;set;}
    private static List<Respuesta> _respuestas {get;set;}

    public static string GetUsername(){
        return _username;
    }
    public static int GetPregCorrectas(){
        return _cantidadPreguntasCorrectas;
    }
    public static int GetPregCont(){
        return preguntasCont;
    }
    public static void InicializarJuego(){
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
        preguntasCont = 0;
    }
    public static List<Categoria> ObtenerCategorias(){return BD.ObtenerCategorias();}
    public static List<Dificultad> ObtenerDificultades(){return BD.ObtenerDificultades();}
    public static bool CargarPartida(string username, int dificultad, int categoria){
        _username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
        return _preguntas.Count > 0;
    }
    public static Pregunta ObtenerProximaPregunta(){
        Random rnd = new Random();
        if(_preguntas.Count > 0){
            int num = rnd.Next(0, (_preguntas.Count-1));
            Pregunta random = _preguntas[num];
            _preguntas.RemoveAt(num);
            return random;
        }else{
            return null;
        }
    }
    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){
        List<Respuesta> respuestas = new List<Respuesta>();
        for (int i = 0; i < _respuestas.Count; i++){
            if (_respuestas[i].IdPregunta == idPregunta){
                respuestas.Add(_respuestas[i]);
            }
        }
        preguntasCont++;
        return respuestas;
    }
    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){
        List<Respuesta> respuestas = new List<Respuesta>();
        for (int i = 0; i < _respuestas.Count; i++){
            if (_respuestas[i].IdPregunta == idPregunta){
                respuestas.Add(_respuestas[i]);
            }
        }
        int j = 0;
        bool correcta = false;
        while(j<respuestas.Count){
            if(respuestas[j].IdRespuesta == idRespuesta){
                correcta = respuestas[j].Correcta;
            }
            j++;
        }
        if(correcta){
            _puntajeActual += 3;
            _cantidadPreguntasCorrectas++;
        }
        return correcta;
    }
}