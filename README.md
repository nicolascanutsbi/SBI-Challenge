Evaluación de Pre Ingreso
Requerimientos
Se debe crear un método de api que haga transformación de datos utilizando las librerías
mediatR y automapper con C#, .NET Core (Framework 5.0)

● Crear una api con las tecnologías mencionadas
● Crear un controlador con un método, que acepte como queryparam el campo -> int
id
● Mediante inyección de dependencia, instanciar la librería MediatR en el controlador.
● Se debe invocar un request handler utilizando la mencionada librería,
mediator.Send( request )
● Dentro del RequestHandler, se debe realizar una llamada Http a la api:
https://jsonplaceholder.typicode.com/posts
La cual devuelve un array de datos dummy con este formato:
{
"userId": 1,
"id": 1,
"title": "sunt aut facere repellat provident occaecati excepturi
optio reprehenderit",
"body": "quia et suscipit\nsuscipit recusandae consequuntur
expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum
rerum est autem sunt rem eveniet architecto"
}

Se debe deserializar los datos en un array de
class ServerPost {
public int userId { get; set; }
public int id { get; set; }
public string title { get; set; }
public string body { get; set; }
}

● Se debe buscar en el array aquel id que coincida con el proporcionado en el
queryParam id.
● Luego utilizando la libreria automapper, se debe mapear el item correspondiente a:
class Salida {
public int Id { get; set; }
public string Titulo { get; set; }
}
● Finalmente, el controller debe devolver la clase Salida como json
Entregable
Entregar solución en un archivo zip mediante correo o bien publicado en github

Recursos

https://github.com/jbogard/MediatR/wiki
Secciones -> Basics / Request / Response
https://docs.automapper.org/en/latest/Configuration.html
Secciones -> Profile Instances / Assembly Scanning for auto configuration
https://docs.automapper.org/en/latest/Dependency-injection.html
Seccion -> Examples / ASP.NET Core
