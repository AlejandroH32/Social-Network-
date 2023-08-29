using CsHarpSocialNetworkManager.Models;
using CsHarpSocialNetworkManager.Utilitis._Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new AppManager(new LogJson ());
            

        while (true) { 

                    Console.WriteLine($"Bienvenido a {app.AppTitle}");

                    Console.WriteLine($"Redes sociales disponibles");

                    var opcionSelected = int.Parse(Console.ReadLine());

                
                     foreach (var item in app.SocialsNetworks.Concat(app.socialNetworksWithGrouops))
                        {
                        Console.WriteLine($"{item.Name}");
                     }

                    Console.WriteLine("Escriba el nombre de la red spcial a la que desee ingresar");

                    string socialNetworkName = Console.ReadLine();

                   var socialNetworkSelected = app.SocialsNetworks.FirstOrDefault(p => p.Name.ToLower() == socialNetworkName);

                   Console.Write(app.GetSocialNetWorkInformation(socialNetworkSelected));

                    var socialNetworkWithGroupsSelected = app.socialNetworksWithGrouops.FirstOrDefault(p => p.Name.ToLower() == socialNetworkName);

                    Console.Write(app.GetSocialNetWorkInformation(socialNetworkWithGroupsSelected));

                    Console.WriteLine("");
                    Console.WriteLine("1= Agraguegar nuevo user , 2= para las estadisticas");
                switch (opcionSelected)
                {
                    case 1:
                        Console.WriteLine("porfavor ingrese su Nombre");
                        string Name = Console.ReadLine();
                        Console.WriteLine("porfavor ingrerse su Email");
                        string Email = Console.ReadLine();
                        Console.WriteLine("porfavor ingrese su edad");
                        short Age = short.Parse(Console.ReadLine());



                        var user = new User();
                        user.Name = Name;
                        user.Email = Email;
                        user.Age = Age;
                        user.dateCreated = DateTime.Now;

                        if (user.IsValid())
                        {
                            Console.WriteLine("sus datos son:");
                            Console.WriteLine($"Nombre: {user.Name}");
                            Console.WriteLine($"Correo : {user.Email}");
                            Console.WriteLine($"Edad: {user.Age}");
                            Console.WriteLine($"Estado activo: {user.IsActive}");

                        }
                        else
                        {
                            Console.WriteLine("user data is not valid ");
                        }
                        if (socialNetworkSelected != null)
                        {
                            int indexElemnt = app.SocialsNetworks.IndexOf(socialNetworkSelected);
                            app.SocialsNetworks[indexElemnt].users.Add(user);
                        }

                        if (socialNetworkWithGroupsSelected != null)
                        {
                            int indexElemnt = app.socialNetworksWithGrouops.IndexOf(socialNetworkWithGroupsSelected);
                            app.socialNetworksWithGrouops[indexElemnt].users.Add(user);
                        }

                        break;

                    case 2:

                       if(socialNetworkSelected != null)
                        {
                           Console.WriteLine( app.GetSocialNetWorkStats(socialNetworkSelected));
                        
                        }
                        if (socialNetworkWithGroupsSelected != null)
                        {
                            Console.WriteLine(app.GetSocialNetWorkStats(socialNetworkWithGroupsSelected));
                        } 
 
                        break;
                    
                }           
            Console.ReadLine();
            }
        }
    }
}
