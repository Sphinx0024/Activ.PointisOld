using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Logics
{
    public class ConstanteNotification
    { 
        public const string obj_pointage = "Pointage";
        public const string obj_fraude = "Alerte Fraude";
        public const string obj_retard = "Retard au Service";
        public const string obj_absence = "Absence au Service";
        public const string msg_retard = "Cher(e) {0}, nous vous informons que l'employé(e) {1} est en retard au service.<br/>Votre heure d'arriver est : {2} le {3}.";
        public const string msg_absence = "Bonjour cher(e) {0}, vous êtes absent au service.";
        public const string msg_absence_responsable = "Cher(e) {0},<br/> ci dessous la liste des absents au service :<br/>";
        public const string msg_pointage = "Cher(e) {0}, vous venez d'être pointé sur Pointis à {1}.";
        public const string msg_retard_emp = "Cher(e) {0}, nous vous informons que vous êtes en retard.<br/>Votre heure d'arriver est : {1} le {2}. <br/> <b>Pointis<b/>";
        public const string msg_fraude_emp = "Cher(e) {0}, nous vous informons qu'il se pourrait que votre journée d'hier ne soit pas comptabiliser comme jour de travail en raison du non pointage du soir.<br/>Veuillez prendre attache avec les ressource humaines pour plus d'informations. <br/> <b>Pointis<b/>";
        //public const string obj_retard = "Bienvenue sur notre plateforme de fidélité";
        //public const string obj_rest = "Nouveau mot de passe de la plateforme de fidélité";
        //public const string msg_inscription = "Cher(e) {0},<br><br>Nous sommes ravis de vous accueillir sur notre plateforme. Votre inscription a été réussie et vous pouvez maintenant profiter de tous nos services.<br><br>Voici vos informations d'accès :<br>- Nom d'utilisateur : {1}<br>- Adresse e-mail : {2}<br><br><a href='{3}'>Cliquez sur ce lien afin d'activer votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br><br>Nous vous souhaitons une excellente expérience sur notre plateforme !<br><br>Cordialement,<br>Equipe technique BNI";
        //public const string msg_utilisateur = "Cher(e) {0},<br><br>Nous sommes ravis de vous accueillir sur notre plateforme. La création de votre compte a été réussie et vous pouvez maintenant profiter de tous nos services.<br><br>Voici vos informations d'accès :<br>- Nom d'utilisateur : {1}<br>- Mot de passe : {2}<br>- Adresse e-mail : {3}<br><br><a href='{4}'>Cliquez sur ce lien afin de vous connecter à votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br><br>Nous vous souhaitons une excellente expérience sur notre plateforme !<br><br>Cordialement,<br>Equipe technique BNI";
        //public const string msg_utilisateur_mdp_edit = "Cher(e) {0},<br><br>Nous sommes ravis de vous informer que votre mot de passe a été reinitialiser avec succes.<br><br>Voici vos nouvelles informations d'accès :<br>- Nom d'utilisateur : {1}<br>- Mot de passe : {2}<br>- Adresse e-mail : {3}<br><br><a href='{4}'>Cliquez sur ce lien afin de vous connecter à votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br><br>Nous vous souhaitons une excellente expérience sur notre plateforme !<br><br>Cordialement,<br>Equipe technique BNI";
        //public const string msg_reset = "Votre mot de passe a été reinitialiser avec succès.<br><br>Voici vos nouvelles informations d'accès :<br>- Adresse e-mail : {0}<br>- Mot de passe : {1}<br><br><a href='{2}'>Cliquez sur ce lien afin de vous connecter à votre compte et profiter de nos services</a>. Si vous avez des questions ou besoin d'assistance, notre équipe de support est là pour vous aider.<br><br>Nous vous souhaitons une excellente expérience sur notre plateforme !<br><br>Cordialement,<br>Equipe technique BNI";

    }
}