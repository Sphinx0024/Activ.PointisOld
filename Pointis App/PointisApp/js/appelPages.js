// Administrateur

$(document).ready(function () {
    $('#pageBoard').click(function () {
        $.ajax({
            url: 'pages/board.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                $('#content-main').html('Erreur lors du chargement des données.');
            }
        });
    });
});


$(document).ready(function () {
    $('#pageSecteur').click(function () {
        $.ajax({
            url: 'pages/secteur.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                $('#content-main').html('Erreur lors du chargement des données.');
            }
        });
    });
});


$(document).ready(function () {
    $('#pagePointage').click(function () {
        $.ajax({
            url: 'pages/pointage.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                // $('#reponseAjax').html('Erreur lors du chargement des données.');
            }
        });
    });
});


$(document).ready(function () {
    $('#pageParametre').click(function () {
        $.ajax({
            url: './pages/parametre.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                // $('#reponseAjax').html('Erreur lors du chargement des données.');
            }
        });
    });
});


$(document).ready(function () {
    $('#pageAbsence').click(function () {
        $.ajax({
            url: './pages/listabsence.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                // $('#reponseAjax').html('Erreur lors du chargement des données.');
            }
        });
    });
});
/*$(document).ready(function () {
    $('#pageAdminUtil').click(function () {
        $.ajax({
            url: 'index.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
               // $('#reponseAjax').html('Erreur lors du chargement des données.');
            }
        });
    });
});*/


// Utilisateur


$(document).ready(function () {
    $('#pageBoardUtil').click(function () {
        alert("test");
        $.ajax({
            url: 'pages/utilisateur/board.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                $('#content-main').html('Erreur lors du chargement des données.');
            }
        });
    });
});


$(document).ready(function () {
    $('#pageEquipeUtil').click(function () {
        $.ajax({
            url: 'pages/utilisateur/equipe.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                $('#content-main').html('Erreur lors du chargement des données.');
            }
        });
    });
});

$(document).ready(function () {
    $('#pageEquipeUtil').click(function () {
        $.ajax({
            url: 'pages/utilisateur/equipe.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#content-main').html(data);
            },
            error: function () {
                $('#content-main').html('Erreur lors du chargement des données.');
            }
        });
    });
});


/*$(document).ready(function () {
    $('#semainePoint').click(function () {
        $.ajax({
            url: 'pages/utilisateur/pointageSemaine.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#show').html(data);
            },
            error: function () {
                $('#show').html('Erreur lors du chargement des données.');
            }
        });
        $("#vu").html("Vue de la semaine");
    });
});


$(document).ready(function () {
    $('#moisPoint').click(function () {
        $.ajax({
            url: 'pages/utilisateur/pointageMois.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#show').html(data);
            },
            error: function () {
                $('#show').html('Erreur lors du chargement des données.');
            }
        });
        $("#vu").html("Vu du mois");
    });
});


$(document).ready(function () {
    $('#jourPoint').click(function () {
        $.ajax({
            url: 'pages/utilisateur/PointageJour.html',
            method: 'GET',
            dataType: 'html',
            success: function (data) {
                $('#show').html(data);
            },
            error: function () {
                $('#show').html('Erreur lors du chargement des données.');
            }
        });
        $("#vu").html("Vu du jour");
    });
});*/