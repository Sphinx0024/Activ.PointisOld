<!DOCTYPE html>
<html class="h-100" lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width,initial-scale=1">
  <script src="https://cdn.tailwindcss.com"></script>
  <title>POINTIS</title>
  <!-- Favicon icon -->
  <!-- <link rel="icon" type="image/png" sizes="16x16" href="#"> -->
  <link href="css/FormPointis.css" rel="stylesheet">
  <link rel="stylesheet" href="css/bootstrap.min.css">


  <!-- favicon -->
  <link rel="apple-touch-icon" sizes="180x180" href="favicon/apple-touch-icon.png">
  <link rel="icon" type="image/png" sizes="32x32" href="favicon/favicon-32x32.png">
  <link rel="icon" type="image/png" sizes="16x16" href="favicon/favicon-16x16.png">
  <link rel="manifest" href="favicon/site.webmanifest">
  <link rel="mask-icon" href="/safari-pinned-tab.svg" color="#5bbad5">
  <meta name="msapplication-TileColor" content="#da532c">
  <meta name="theme-color" content="#ffffff">


  <style>
    .overlayer-none,
    .loader-none {
      display: none;
    }

    .overlayer {
      width: 100%;
      height: 100%;
      position: fixed;
      z-index: 7100;
      background: rgba(255, 255, 255, 0.4);
      top: 0;
      left: 0;
      right: 0;
      bottom: 0;
    }

    .loader {
      z-index: 7700;
      position: fixed;
      top: 50%;
      left: 50%;
      -webkit-transform: translate(-50%, -50%);
      -ms-transform: translate(-50%, -50%);
      transform: translate(-50%, -50%);
    }
  </style>

  <script type="text/javascript">
    var onloadCallback = function() {
      grecaptcha.render('html_element', {
        'sitekey': '6LeXFcYlAAAAAGRdDDj2cZBkchqzkQYUZoCxU3HP'
      });
    };
  </script>
  <script src="https://smtpjs.com/v3/smtp.js"></script>
</head>

<body class="corp h-100  ">
  <!-- <div>
        <img src="images/media/img-gps.png">
    </div> -->
  <!-- <div class=" p-4 border-green-600 "> -->
  <!-- <div class="flex-none relative ml-20">
        <img src="images/media/img-gps.png" class="absolute inset-0 "/>
      </div> -->


  <header class="site-navbar js-sticky-header site-navbar-target" role="banner">
    <div class="overlayer-none"></div>
    <div class="loader-none">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>

    <div class="container-fluid">
      <div class="row align-items-center">

        <div class="col-6 col-xl-2">
          <div class="mb-0 site-logo">
            <!-- <a href="index.html" class="mb-0"><img src="images/_pointIS.png" class="img-fluid" width="40%" alt=""><span class="text-primary"></span> </a> -->
            <a href="index.html"><img src="images/_pointIS.png" width="100"></a>

          </div>
        </div>

      </div>
    </div>

  </header>

  <!-- 
  <nav class="">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="relative flex h-16 items-center justify-between">
        <div class="absolute inset-y-0 left-0 flex items-center sm:hidden">

        </div>
        <div class="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">

          <div class="hidden sm:ml-6 sm:block">
            <div class="flex space-x-4">
              <a href="index.html"><img src="images/_pointIS.png" class="w-16 ml-3"></a>
            </div>

          </div>
        </div>

      </div>
    </div>


  </nav> 
-->

  <!-- <div class=" rounded-2xl formbold-main-wrapper bg-slate-100 mr-10  ml-60 mt-0 mb-10 pr-4  shadow-lg shadow-back-500/50"> -->
  <div class=" rounded-2xl formbold-main-wrapper bg-slate-100  m-auto  shadow-lg shadow-back-500/50" style="width: 70%;">
    <!-- Author: FormBold Team -->
    <!-- Learn More: https://formbold.com -->
    <!-- <div class="formbold-form-wrapper"> -->
    <div class="img">
      <img src="images/img-gps.png" class="object-cover rounded-l-2xl " />
    </div>
    <form class=" m-3">

      <div class="formbold-steps ml-2 mt-0" style=" display: flex; flex-direction: row ; justify-content: center;">

        <ul style=" display: flex; flex-direction: row ;  align-items: center;">
          <li class="formbold-step-menu1 active" style="display: flex; flex-direction: column;">
            <span id="li1">1</span>
            Société
          </li>
          <li id="li12" class="li12" style="height:3px; width:100px; border-radius:15px/15px;"></li>
          <li class="formbold-step-menu2" style="display: flex; flex-direction: column;">
            <span id="li2">2</span>
            Administrateur
          </li>
          <li id="li23" class="li23" style="height:3px; width:80px; border-radius:15px/15px;"></li>
          <li class="formbold-step-menu3" style="display: flex; flex-direction: column;">
            <span id="li3">3</span>
            Resumé
          </li>
        </ul>
      </div>

      <div class="formbold-form-step-1 active ml-2">
        <div>
          <label for="firstname" class="formbold-form-label"> Nom de l'entreprise </label>
          <input type="text" name="nom_entrep" placeholder="Nom de l'entreprise" id="user_name" class="formbold-form-input " />
        </div>
        <div>
          <label for="lastname" class="formbold-form-label"> RCCM </label>
          <input type="text" name="rccm" placeholder="RCCM" id="RCCM" class="formbold-form-input" />
        </div>
        <div>
          <label for="dob" class="formbold-form-label"> Localisation </label>
          <input type="text" name="loc" placeholder="Localisation" id="localisation" class="formbold-form-input" />
        </div>
        <div class="formbold-input-flex">


        </div>

        <div class="formbold-input-flex">
          <div>
            <label for="address" class="formbold-form-label"> Telephone </label>
            <input type="text" name="address" id="tel_entreprise" placeholder="Telephone" class="formbold-form-input" />
          </div>
          <div>
            <label for="email" class="formbold-form-label"> Adresse mail </label>
            <input type="email" name="email" placeholder="Adresse mail" id="email" class="formbold-form-input" />
          </div>
        </div>


      </div>

      <div class="formbold-form-step-2 ml-2">
        <div class="formbold-input-flex">
          <div>
            <label for="firstname" class="formbold-form-label">Nom </label>
            <input type="text" name="firstname" placeholder="Nom " id="nom_admin" class="formbold-form-input" />
          </div>
          <div>
            <label for="lastname" class="formbold-form-label"> Prenom</label>
            <input type="text" name="prenom" placeholder="Prenom" id="prenom_admin" class="formbold-form-input" />
          </div>
        </div>
        <div>
          <div class="formbold-input-flex">
            <div>
              <label for="firstname" class="formbold-form-label"> Adresse mail </label>
              <input type="text" name="firstname" placeholder="Adresse mail personnel" id="email_admin" class="formbold-form-input" />
            </div>

            <div>
              <label for="lastname" class="formbold-form-label"> Telephone </label>
              <input type="text" name="lastname" placeholder="Telephone" id="tel_admin" class="formbold-form-input" />
            </div>
          </div>
          <!--<div class="formbold-input-flex">

            <!-- <div class="custom-select"> -->
            <!--<div>
              <label for="sex_admin" class="formbold-form-label ">Sexe</label>
              <select id="sex_admin" class="formbold-form-input">
                <option value="" class="text-center">--Selectionnez votre genre--</option>
                <option value="M" class="text-center">Masculin</option>
                <option value="F" class="text-center">Feminin</option>

              </select>

            </div>
          </div>-->
        </div>

      </div>

      <div class="formbold-form-step-3 ml-2">
        <!-- <div class=""> -->
        <div class="grid grid-rows-2 gap-2 ">
          <!-- <h1>Informations sur l'entreprise</h1> -->


          <div class="grid grid-cols-2" style="font-size: small; display:flex; flex-direction: column">
            <div class="h-10 font-bold">Société</div>
            <div>
              <div>

                <div>
                  <label class="font-medium">Nom:</label>
                  <span id="nom_eAf" class="span"></span>
                </div>
                <div class="">
                  <label class="font-medium">RCCM :</label>
                  <span id="rccm_Af"></span>
                </div>
                <div class="">
                  <label class="font-medium">Localisation :</label>
                  <span id="loc_Af"></span>
                </div>
              </div>
              <div>
                <div class="">
                  <label class="font-medium">Email :</label>
                  <span id="email_Af"></span>
                </div>
                <div class="">
                  <label class="font-medium">Telephone :</label>
                  <span id="tel_eAf"></span>
                </div>
              </div>
            </div>
          </div>

          <!-- <h1>Informations sur l admin/h1>  -->

          <!-- <div class="h-10 font-bold">Administrateur</div> -->
          <div class=" grid grid-cols-2 " style="font-size: small;display:flex; flex-direction: column;">
            <!-- <span class="font-bold ">Administrateur </span>  -->
            <div class="h-10 font-bold">Administrateur</div>
            <div>
              <div class="">
                <label class="font-medium">Email :</label>
                <span id="email_pAf"></span>
              </div>
              <div class="">
                <label class="font-medium">Nom :</label>
                <span id="nom_Af" class="span"></span>
              </div>
              <div class="">
                <label class="font-medium">Prenom :</label>
                <span id="prenom_Af"></span>
              </div>
            </div>



            <div>
              <div class="">
                <label class="font-medium">Telephone :</label>
                <span id="tel_Af"></span>
              </div>
              <!-- <div class="">
                <label class="font-medium">Sexe :</label>
                <span id="sex_Af"></span>
              </div> -->

            </div>


          </div>
          <div class=" grid grid-cols-2 ">
            <div class="recaptcha" id="recaptcha">
              <div class="">
                <div id="html_element"></div>
              </div>
            </div>
          </div>
        </div>

      </div>

      <div class="formbold-form-btn-wrapper">

        <button class="formbold-back-btn " id="formbold_btn" style="background-color:transparent;color:#000;">
          Retour
        </button>



        <button class="formbold-btn" id="formbold_btn">
          Suivant
        </button>
      </div>

    </form>
  </div>



  <script>
    function sendMail(idconnex) {

      const raisonSoConst = document.getElementById("user_name").value;
      const emailEntConst = document.getElementById("email").value;
      const preAdConst = document.getElementById("prenom_admin").value;
      const nomAdConst = document.getElementById("nom_admin").value;
      const emailAdConst = document.getElementById("email_admin").value;
      const space = " ";
      //const defaultMDPConst = password;
      const idConConst = idconnex;
      const lien = "http://localhost:8080/POINTISDEMO/PointisWeb/emailverifie.html?mail=" + emailAdConst + "&id=" + idConConst;
      //format text 
      let ebody = `
                <p>Cher, </p> ${preAdConst} ${space} ${nomAdConst}
                <br />
                <p>Votre email doit être authentifié</p>
                <br />
                <p>Pour cela veillez cliquez sur ce <a href="${lien}">lien</a> pour verifier votre email</p> 
                <br>
                <p>Cordialement.</p>
                <br/>
                <center>@Pointis</center>
                `

      // Use token method
      Email.send({
        SecureToken: "193b80ea-7547-40a3-bafa-b8eb082adeb5",
        To: emailAdConst,
        From: 'pointisapp@gmail.com',
        Subject: "Enregistrement de " + raisonSoConst + " sur POINTIS !",
        Body: ebody
      }).then(

        message => location.replace('./succes.php')
        //message => location.replace('./succes.php')
        //message => alert(message)
      );
      //location.replace('./succes.php');
    }


    const stepMenuOne = document.querySelector('.formbold-step-menu1')
    const stepMenuTwo = document.querySelector('.formbold-step-menu2')
    const stepMenuThree = document.querySelector('.formbold-step-menu3')

    const stepOne = document.querySelector('.formbold-form-step-1')
    const stepTwo = document.querySelector('.formbold-form-step-2')
    const stepThree = document.querySelector('.formbold-form-step-3')

    const formSubmitBtn = document.querySelector('.formbold-btn')
    const formBackBtn = document.querySelector('.formbold-back-btn')
    const cap = document.querySelector('.recaptcha')



    // var inputs = document.querySelectorAll('input[name="nom_e"], input[name="rccm"], input[name="email"], input[name="tel"], input[name="loc"]');
    // var ids = Array.from(inputs).map(input => input.id);
    // ids.required=true
    // var formulaire =  document.querySelector('form')


    function enregistrement() {
      var ne = document.getElementById('user_name').value;
      var r = document.getElementById('RCCM').value;
      var l = document.getElementById('localisation').value;
      var e = document.getElementById('email').value;
      var t = document.getElementById('tel_entreprise').value;
      var n = document.getElementById('nom_admin').value;
      var p = document.getElementById('prenom_admin').value;
      var ep = document.getElementById('email_admin').value;
      var tp = document.getElementById('tel_admin').value;
      //var s = document.getElementById('sex_admin').value;
      var s = "Non défini";

      document.querySelector('.overlayer-none').className = 'overlayer';
      document.querySelector('.loader-none').className = 'loader';


      var data = {
        RaisonSocialeSoc: ne,
        RCCMSoc: r,
        EmailSoc: e,
        TelephoneSoc: t,
        LocalisationSoc: l,
        Nom: n,
        Prenom: p,
        Email: ep,
        Telephone: tp,
        Sexe: s,

      };



      fetch('https://face.activactions.net/api/Societe/Inscription', {
          method: 'POST',
          headers: {
            'content-type': 'application/json'
          },
          body: JSON.stringify(data)
        })
        .then(res => res.json())
        .then(data => {
          if (data.length > 0) {

            let dataValue = data;

            let value = dataValue.split('#');
            let idConnexion = value[1];

            fetch('https://face.activactions.net/api/Connexion/Get/' + idConnexion).then(function(response) {
              return response.text()
            }).then(function(text) {
              let tab = text.split('"');
              let pass = tab[9];
              sendMail(idConnexion);
              //location.replace = "./inscriptionreussi.html";
              //redirectionApresDelai();
            });

          } else {
            alert("Veuillez réessayer plutard !! Erreur serveur");
          }
        });


    };

    function recap() {

      document.getElementById("formbold_btn").addEventListener("click", function(e) {
        var response = grecaptcha.getResponse();
        if (response.length == 0) {
          //reCaptcha not verified
          alert("Merci de confirmer que vous etes un humain. SVP !!");
          e.preventDefault();
          return false;
        } else {
          //enregistrement();
          return true;
          //   location.replace('./emailverifie.html');
        }
      })
      //captcha verified
      //do the rest of your validations here

    }

    /*function redirectionApresDelai() {
      setTimeout(function() {
        window.location.replace = "./inscriptionreussi.html"; }, 5000); 
    }*/


    function validerEtape1() {

      var champ1 = document.getElementById('user_name');
      var champ2 = document.getElementById('RCCM');
      var champ3 = document.getElementById('localisation');
      var champ4 = document.getElementById('email');
      var champ5 = document.getElementById('tel_entreprise');
      var li1 = document.getElementById('li1');

      var li12 = document.getElementById('li12');


      if (champ1.value === '' || champ2.value === '' || champ3.value === '' || champ4.value === '') {
        alert('Veuillez remplir tous les champs avant de passer à l\'étape suivante.');

        li1.style.background = '#DDE3EC';
        li1.style.color = '#536387';

        li12.style.background = '#DDE3EC';


        return false
      } else {

        li1.style.background = '#DC6502';
        li1.style.color = '#FFFFFF';

        li12.style.background = '#DC6502';



      }

      return true
    }

    function validerEtape2() {

      var champ1 = document.getElementById('nom_admin');
      var champ2 = document.getElementById('prenom_admin');
      var champ3 = document.getElementById('email_admin');
      var champ4 = document.getElementById('tel_admin');

      var li2 = document.getElementById('li2');

      var li23 = document.getElementById('li23');

      //   var champ5 = document.getElementById('matricule_admin');
      //  var champ6 = document.getElementById('fn_admin');

      if (champ1.value === '' || champ2.value === '' || champ3.value === '' || champ4.value === '') {
        alert('Veuillez remplir tous les champs avant de passer à l\'étape suivante.');

        li2.style.background = '#DDE3EC';
        li2.style.color = '#536387';

        li23.style.background = '#DDE3EC';


        return false;
      } else {
        li2.style.background = '#DC6502';
        li2.style.color = '#FFFFFF';

        li23.style.background = '#DC6502';




      }

      return true;
    }

    // 
    //     // && validerEtape2()
    //     function changeClass() { 
    //     document.getElementById('recaptcha').className = "newClass"; 
    // }
    formSubmitBtn.addEventListener("click", function(event) {

      event.preventDefault()
      if (stepMenuOne.className == 'formbold-step-menu1 active' && validerEtape1()) {
        event.preventDefault()


        stepMenuOne.classList.remove('active')
        stepMenuTwo.classList.add('active')

        stepOne.classList.remove('active')
        stepTwo.classList.add('active')


        formBackBtn.classList.add('active')
        formBackBtn.addEventListener("click", function(event) {
          event.preventDefault()

          stepMenuOne.classList.add('active')
          stepMenuTwo.classList.remove('active')

          stepOne.classList.add('active')
          stepTwo.classList.remove('active')
          cap.classList.add('active')
          formBackBtn.classList.remove('active')


        });


      } else if (stepMenuTwo.className == 'formbold-step-menu2 active' && validerEtape2()) {
        event.preventDefault()

        stepMenuTwo.classList.remove('active')
        stepMenuThree.classList.add('active')

        stepTwo.classList.remove('active')
        stepThree.classList.add('active')

        formSubmitBtn.innerHTML = "Confimer"

        formBackBtn.classList.add('active')
        formBackBtn.addEventListener("click", function(event) {
          event.preventDefault()

          stepMenuThree.classList.remove('active')
          stepMenuOne.classList.remove('active')
          stepMenuTwo.classList.add('active')

          stepThree.classList.remove('active')
          stepOne.classList.remove('active')
          stepTwo.classList.add('active')
          formSubmitBtn.innerHTML = "Suivant"
          // stepMenuTwo.classList.add('active')
          formBackBtn.classList.add('active')
          formBackBtn.addEventListener("click", function(event) {
            event.preventDefault()

            stepMenuOne.classList.add('active')
            stepMenuTwo.classList.remove('active')

            stepOne.classList.add('active')
            stepTwo.classList.remove('active')

            formBackBtn.classList.remove('active')
            formSubmitBtn.innerHTML = "Suivant";

          });
        });


        // formBackBtn.classList.remove('active')

        //   formBackBtn.classList.remove('active')
        //   formSubmitBtn.textContent = 'Submit'
      } else if (stepMenuThree.className == 'formbold-step-menu3 active') {
        event.preventDefault()
        recap()
        enregistrement()
        //redirectionApresDelai()
        //   location.replace('./emailverifie.html');

      }

      //recuperation des donnees
      var ne = document.getElementById('user_name').value;
      var r = document.getElementById('RCCM').value;
      var l = document.getElementById('localisation').value;
      var e = document.getElementById('email').value;
      var t = document.getElementById('tel_entreprise').value;
      var n = document.getElementById('nom_admin').value;
      var p = document.getElementById('prenom_admin').value;
      var ep = document.getElementById('email_admin').value;
      var tp = document.getElementById('tel_admin').value;
      // var m = document.getElementById('matricule_admin').value
      //  var f = document.getElementById('fn_admin').value
      //var s = document.getElementById('sex_admin').value
      var s = 'Non defini';



      var data = {
        RaisonSocialeSoc: ne,
        RCCMSoc: r,
        EmailSoc: e,
        TelephoneSoc: t,
        LocalisationSoc: l,
        Nom: n,
        Prenom: p,
        Email: ep,
        Telephone: tp
        //Sexe: s
      };
      console.log(data);


      document.getElementById('nom_eAf').innerHTML = data.RaisonSocialeSoc;
      document.getElementById('rccm_Af').innerHTML = data.RCCMSoc;
      document.getElementById('loc_Af').innerHTML = data.LocalisationSoc;
      document.getElementById('email_Af').innerHTML = data.EmailSoc;
      document.getElementById('tel_eAf').innerHTML = data.TelephoneSoc;
      document.getElementById('email_pAf').innerHTML = data.Email;
      document.getElementById('nom_Af').innerHTML = data.Nom;
      document.getElementById('prenom_Af').innerHTML = data.Prenom;
      //   document.getElementById('fonc_Af').innerHTML = data.Titre
      document.getElementById('tel_Af').innerHTML = data.Telephone;
      //document.getElementById('mat_Af').innerHTML = data.Matricule
      //document.getElementById('sex_Af').innerHTML = data.Sexe



    });
  </script>
  <script src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit" async defer></script>

</body>

</html>