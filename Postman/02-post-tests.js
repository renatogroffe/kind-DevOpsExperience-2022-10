pm.test("Retorno OK Cadastrar Chamado", function() {
    pm.response.to.be.ok;
    pm.response.to.json;
    pm.response.to.be.withBody;
});

var result = pm.response.json();

pm.test("Verificar se o Id do Chamado foi gerado", function() {
    pm.expect(result.idChamado).not.undefined;
    pm.expect(result.idChamado).not.null;
    pm.collectionVariables.set("idChamado", result.idChamado)
});