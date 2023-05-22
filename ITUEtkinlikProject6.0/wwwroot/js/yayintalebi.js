KampusSec = {
    //Fonksiyon tanımı başlıyor.
    salonAdiGetir: function(arg)
    {
        var kampusId = arg[arg.selectedIndex].value;
        //arg parametresi bir HTML öğesi olduğu varsayılarak, seçili olan öğenin değeri arg.selectedIndex ile alınıyor ve kampusId değişkenine atanıyor.
        // Asenchronious javascript xml. => AJAX
        // JQuery kütüphanesinden gelir.
        //Asenkron JavaScript XML (AJAX) kullanılarak backend'e istek atılıyor
        $.ajax({
            type: "POST",                 // tip'i yazıyorsun. Get, Post, PATCH vb.
            url: "/Member/YayinTalebi/SalonlariGetir?kampusId="+kampusId, // Backend tarafında istek atacağın url' i yazıyorsun.
            data: kampusId,                   // string türünde datanı gönderiyorsun. !!!
            success: function (data) {   // Backend'den bana geri dönen json türündeki verileri temsil eder.
              /*  debugger;*/
                var htmlElement = '<option>Salon Seçiniz</option>';
                $.each(data, function (index) { //{1,2,3,4,5,6}
                    htmlElement += "<option value=' " + data[index].salonId + "' >" + data[index].salonAdi + "</option>'";
                });
                $('#Salonlar').html(htmlElement);

            },     // Success kısmında Back-End'den veri geri döndüğünde ne yapılcağı yazılır !
            errors: function (error) {
                console.log(error)
            },        // Burda hata dönerse ne yapılacak o yazılır.
            contentType: "application/json", // İstek gövdesinin veri tipi belirtilir.
            dataType: "json",                // Beklenen yanıtın veri tipi belirtilir
        });
    } 
}