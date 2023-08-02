$(function () {
    $("#BuscarCEPLinkButton").click(function (e) {

        var cep = $("#CEPTextBox").val().replace(/\D/g, '');
        var validacep = /^[0-9]{8}$/;

        LimpaDadosEndereco();

        if (cep != "" && validacep.test(cep)) {
            $("#RuaTextBox").val("...");
            $("#BairroTextBox").val("...");
            $("#CidadeTextBox").val("...");
            $("#UFTextBox").val("...");

            //var url = "https://viacep.com.br/ws/" + cep + "/json";
            
            //$.getJSON(url, function (dados) {
            //    if (!("erro" in dados)) {
            //        $("#RuaTextBox").val(dados.logradouro);
            //        $("#BairroTextBox").val(dados.bairro);
            //        $("#CidadeTextBox").val(dados.localidade);
            //        $("#UFTextBox").val(dados.uf);
            //    }
            //    else {
            //        LimpaDadosEndereco();
            //        alert("CEP não encontrado.");
            //    }
            //});
        }
        else {
            alert("Formato de CEP inválido.");
            e.preventDefault();
        }
    });

    function LimpaDadosEndereco() {
        $("#RuaTextBox").val("");
        $("#BairroTextBox").val("");
        $("#CidadeTextBox").val("");
        $("#UFTextBox").val("");
    }
});