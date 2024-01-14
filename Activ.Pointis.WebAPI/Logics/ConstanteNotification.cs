using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Logics
{
    public class ConstanteNotification 
    { 
        public const string obj_pointage = "Pointage de Sortie";
        public const string obj_user = "Enregistrement d'utilisateur";
        public const string obj_fraude = "Alerte Fraude";
        public const string obj_retard = "Retard au Service";
        public const string obj_retard_sortie = "Retard de sortie au Service";
        public const string obj_absence = "Absences au Service";
        public const string obj_absence_semaine = "Absences hebdomandaire au Service";


        //public const string msg_retard = "Cher(e) {0}, nous vous informons que l'employé(e) {1} est en retard au service.<br/>Votre heure d'arriver est : {2} le {3}.";
        public const string msg_retard = "Cher(e) {0},<br/>Vous êtes arrivé(e) en retard au service ce jour {1}.Votre heure d'arrivée est : {2}.";
        public const string msg_absence = "Cher(e) {0},<br/>Vous êtes absent au service ce {1}.";
        public const string msg_absence_semaine_responsable  = "Cher(e) {0},<br/> Veuillez trouver ci-après la liste des absents au service au cours de la semaine du {1} au {2}:<br/>";
        public const string msg_absence_responsable = "Cher(e) {0},<br/> Veuillez trouver ci-après la liste des absents au service ce jour {1} :<br/>";
        public const string msg_pointage = "Cher(e) {0},<br/>Veuillez effectuer à partir de 16h30 votre pointage de sortie de service.";
        public const string msg_retard_emp = "Cher(e) {0},<br/>Vous êtes arrivé(e) en retard au service ce jour {1}.Votre heure d'arrivée est : {2}. <br/>";
        public const string msg_fraude_emp = "Cher(e) {0},<br/>Lors de votre précédent jour de travail, vous n'avez pas effectué votre pointage de sortie de service. Par conséquent, ladite journée pourrait ne pas être comptabilisée comme jour effectif de travail.<br/>Veuillez prendre attache avec les ressource humaines pour plus d'informations.";
        public const string msg_user = "Cher(e) {0},<br/>Vous venez d'etre enregistré sur POINTIS comme utilisateur avec le role de : {1}, <br/> LOGIN : {2} <br/> PASSW0RD : {3} <br/>Cliquez sur ce <a href='{4}'>lien</a> pour vous connecter à Pointis<br/>Cliquez sur ce <a href='{5}'>lien</a> pour télécharger Pointis.";


        public const string msg_retard_sortie = "Cher(e) {0},<br/>Il est précisement : {1} et votre heure de sortie qui est de : {2} a été largement dépassée.<br/> A l'absence d'une justification de votre présence au service à cette heure votre pointage du jour ne sera pas pris en compte";


        public const string lien_store = "https://pointis.activactions.net/store.html?store=2";
        public const string lien_login = "https://pointis.activactions.net/loginPointis.html";

        //public const string obj_retard = "Bienvenue sur notre plateforme de fidélité";
        //public const string obj_rest = "Nouveau mot de passe de la plateforme de fidélité";
        //public const string msg_inscription = "Cher(e) {0},<br/><br/>Nous sommes ravis de vous accueillir sur notre plateforme. Votre inscription a été réussie et vous pouvez maintenant profiter de tous nos services.<br/><br/>Voici vos informations d'accès :<br/>- Nom d'utilisateur : {1}<br/>- Adresse e-mail : {2}<br/><br/><a href='{3}'>Cliquez sur ce lien afin d'activer votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br/><br/>Nous vous souhaitons une excellente expérience sur notre plateforme !<br/><br/>Cordialement,<br/>Equipe technique BNI";
        //public const string msg_utilisateur = "Cher(e) {0},<br/><br/>Nous sommes ravis de vous accueillir sur notre plateforme. La création de votre compte a été réussie et vous pouvez maintenant profiter de tous nos services.<br/><br/>Voici vos informations d'accès :<br/>- Nom d'utilisateur : {1}<br/>- Mot de passe : {2}<br/>- Adresse e-mail : {3}<br/><br/><a href='{4}'>Cliquez sur ce lien afin de vous connecter à votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br/><br/>Nous vous souhaitons une excellente expérience sur notre plateforme !<br/><br/>Cordialement,<br/>Equipe technique BNI";
        //public const string msg_utilisateur_mdp_edit = "Cher(e) {0},<br/><br/>Nous sommes ravis de vous informer que votre mot de passe a été reinitialiser avec succes.<br/><br/>Voici vos nouvelles informations d'accès :<br/>- Nom d'utilisateur : {1}<br/>- Mot de passe : {2}<br/>- Adresse e-mail : {3}<br/><br/><a href='{4}'>Cliquez sur ce lien afin de vous connecter à votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br/><br/>Nous vous souhaitons une excellente expérience sur notre plateforme !<br/><br/>Cordialement,<br/>Equipe technique BNI";
        //public const string msg_reset = "Votre mot de passe a été reinitialiser avec succès.<br/><br/>Voici vos nouvelles informations d'accès :<br/>- Adresse e-mail : {0}<br/>- Mot de passe : {1}<br/><br/><a href='{2}'>Cliquez sur ce lien afin de vous connecter à votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br/><br/>Nous vous souhaitons une excellente expérience sur notre plateforme !<br/><br/>Cordialement,<br/>Equipe technique BNI";

    }
}