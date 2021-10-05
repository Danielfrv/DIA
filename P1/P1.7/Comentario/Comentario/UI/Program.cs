using System;

namespace Comentario
{
    class Program
    {
        static void DemoLambdas()
        {

            Action<string> Out = x => Console.WriteLine(x);
            Func<string, int> Val = (x) => Convert.ToInt32(x);
            Action<string> OutStrUpper = x =>
            {
                x = x.ToUpper();
                Console.WriteLine(x);
                    
            };
            Func<int, int, int> SumaRec = null;
            SumaRec = (x, y) =>
                y == 0 ? x:
                    1 + SumaRec(x, y - 1);

            var comentario1 = new ComentarioTexto(0, "Daniel", "Primero");

            /*Out(Convert.ToString(Val("42")));
            Out(comentario1.ToString());*/

            new XComentario(comentario1).SaveToXml("comentario1.xml");

        }

        static void Main(string[] args)
        {
            var listaComentarios = new ListaComentarios();
            listaComentarios.Inserta(
                new ComentarioTexto(0, "Daniel", "DIA"));
            
            listaComentarios.Inserta(
                new ComentarioTexto(10, "Daniel", "El parcial 1 es eliminatorio"));
            
            listaComentarios.Inserta(
                new ComentarioImagen(40, "Daniel", "https://jonmircha.com/img/blog/vscode.png"));

            foreach (Comentario c in listaComentarios.Todos)
            {
                Console.WriteLine(c);
            }
            
            Console.WriteLine($"Num. Comentarios: {listaComentarios.Num}"); //El símbolo de dólar sirve para interpretar
                                                                            //lo que aparezca entre las llaves
            
            
        }
    }
}