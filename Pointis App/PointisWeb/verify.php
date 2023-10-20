<?php

// recaptcha v3
if (!empty($_POST['email-admin']) && !empty($_POST['email-entreprise'])) {

    $secret = "6LecmMUlAAAAANfWil5_inFLkS2oDLnig-2oY-Yi";
    $response = htmlspecialchars($_POST['g-recaptcha-response']);
    $remoteip = $_SERVER['REMOTE_ADDR'];
    $request = "https://www.google.com/recaptcha/api/siteverify?secret=$secret&response=$response&remoteip=$remoteip";

    $get = file_get_contents($request);
    $decode = json_decode($get, true);

    var_dump($decode);

    if ($decode['success']) {
        echo "Yes";
    } else {
        echo  "No";
    }
}
