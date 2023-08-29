using CsHarpSocialNetworkManager.Utilitis._Log;
using CsHarpSocialNetworkManager.Utilitis.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager.Models
{
    internal class AppManager
    {
        public string AppTitle { get; set; }

        public ILogs<string> logs { get; set; }


        public AppManager(ILogs<string> logger )
        {
            logs = logger;
            AppTitle = "Administrador de redes Sociales";
            SocialsNetworks = new List<SocialsNetwork>();
            socialNetworksWithGrouops = new List<SocialNetworkWithGroups>();
            initiaizeSocialNetworks();
        }

        public void initiaizeSocialNetworks()
        {
            SocialsNetworks.Add(new SocialsNetwork()
            {
                Name = "twitter",
                Description = "Red  social para intercambio de mensajes cortos",
                users = new List<User>(),
                DateCreade = new DateTime(2008, 01, 20)
            });
            SocialsNetworks.Add(new SocialsNetwork()
            {
                Name = "Instagram",
                Description = "Red  social para intercambio de Fotos y videos cortos",
                users = new List<User>(),
                DateCreade = new DateTime(2010, 01, 20)
            });
            socialNetworksWithGrouops.Add(new SocialNetworkWithGroups()
            {
                Name = "Facebook",
                Description = "Red  social para intercambio de Fotos y videos , pensaientos y debates cortos",
                users = new List<User>(),
                Groups = new List<string>() { "Programers CsHarp", "group music", "programers Go" },
                DateCreade = new DateTime(2010, 01, 20)
            });

            logs.saveLog("initiaizeSocialNetworks");
        }

        public List<SocialsNetwork> SocialsNetworks { get; set; }

        public List<SocialNetworkWithGroups> socialNetworksWithGrouops { get; set; }

        public string GetSocialNetWorkInformation<T>(T socialsNetwork)
        {
            if (socialsNetwork == null)
            {
                return "";
            }
            StringBuilder stringBuilder = new StringBuilder();

            var socialsNetworItem = socialsNetwork as SocialsNetwork;

            stringBuilder.AppendLine($"Nombre: {socialsNetworItem.Name}");
            stringBuilder.AppendLine($"Descripcion: {socialsNetworItem.Description}");
            stringBuilder.AppendLine($"Anio de creacion: {socialsNetworItem.DateCreade.Year}");


            if (socialsNetworItem is SocialNetworkWithGroups)
            {
                var socialsNetworWithGroupsItem = socialsNetwork as SocialNetworkWithGroups;
                stringBuilder.AppendLine($"Grupos: {string.Join(",", socialsNetworWithGroupsItem.Groups)}");
            }


            logs.saveLog("GetSocialNetWorkInformation");

            return stringBuilder.ToString();
        }

        public string GetSocialNetWorkStats<T>(T socialsNetwork)
        {
            if (socialsNetwork == null)
            {
                return "";
            }
            StringBuilder stringBuilder = new StringBuilder();

            var socialsNetworItem = socialsNetwork as SocialsNetwork;
            try
            {


                stringBuilder.AppendLine($"Cantidad users: {socialsNetworItem.users.Count}");
                stringBuilder.AppendLine($"Promedio de edad: {socialsNetworItem.users.Average(p => p.Age)}");
                stringBuilder.AppendLine($"El usuario de mayor edad tiene: {socialsNetworItem.users.Max(p => p.Age)}Anios");
                stringBuilder.AppendLine($"El usuario de menor edad tiene: {socialsNetworItem.users.Min(p => p.Age)}Anios");


                if (socialsNetworItem is SocialNetworkWithGroups)
                {
                    var socialsNetworWithGroupsItem = socialsNetwork as SocialNetworkWithGroups;
                    stringBuilder.AppendLine($"Grupos: {socialsNetworWithGroupsItem.Groups.Count}");
                }
            }

            catch (Exception ex)
            {

                logs.saveLog(ex.Message);
            }

            logs.saveLog("GetSocialNetWorkStats");
            return stringBuilder.ToString();

        }



    }   
}
