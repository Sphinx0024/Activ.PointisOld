function employeID() {
    var id = sessionStorage.getItem('idEquipeUser');
    //var id = sessionStorage.getItem('idEmployeUser');
    if (sessionStorage.getItem('idEquipeUser') === null) {
        id = sessionStorage.getItem('idEmployeUser');

        if (sessionStorage.getItem('idEmployeUser') === null) {
            id = sessionStorage.getItem('idEmployeNOUser');
        }
    }
    return id;
}


//import code
function qrGenerate() {
    var socID = sessionStorage.getItem('idSociete');
    var id = employeID();

    var no = '';
    var em = '';
    var tel = '';
    var pre = '';
    var _qrCode = '';
    var url = 'word';

    fetch('https://face.activactions.net/api/Employes/Get/' + socID)
        .then(res => res.json())
        .then(data => {
            for (let item of data) {
                var employeid = item.EmployeID;
                var employemail = item.Email;
                if (employeid == id) {
                    no = item.Nom;
                    pre = item.Prenom;
                    em = item.Email;
                    tel = item.Telephone;

                    url = 'id=' + id + ';nom=' + no + ';prenom=' + pre + ';email=' + em + ';tel=' + tel;
                    _qrCode = 'https://chart.googleapis.com/chart?cht=qr&chs=250x250&chld=L|1&chl=' + url;
                    document.getElementById('qrCodeImg').setAttribute('src', _qrCode);

                }
            }


        });


    // Selon le choix d'API, commentez l'une des deux lignes suivantes et décommentez l'autre

    // _qrCode = 'https://chart.googleapis.com/chart?cht=qr&chs=250x250&chld=L|1&chl=id=' + id + '&nom=' + no + '&prenom=' + pre + '&email=' + em + '&tel=' + tel;
    // _qrCode = 'https://api.qrserver.com/v1/create-qr-code/?size=250x250&data=' + url;


    // document.getElementById('qrCodeImg').setAttribute('src', _qrCode);
    // document.getElementById('qrcode').style.visibility = 'visible';

}

qrGenerate();




