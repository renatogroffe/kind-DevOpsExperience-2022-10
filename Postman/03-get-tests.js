pm.test("Retorno OK Consultar Chamado", function() {
    pm.response.to.be.ok;
    pm.response.to.json;
    pm.response.to.be.withBody;
});

var result = pm.response.json();

pm.test("Checar Id Chamado", function() {
    pm.expect(result.id).not.undefined;
    pm.expect(result.id).not.null;
    pm.expect(result.id).to.eql(pm.collectionVariables.get("idChamado"));
});

pm.test("Checar Data Chamado", function() {
    pm.expect(result.dataChamado).not.undefined;
    pm.expect(result.dataChamado).not.null;
});

pm.test("Checar E-mail", function() {
    pm.expect(result.email).to.eql(pm.collectionVariables.get("email"));
});

pm.test("Checar Descritivo Chamado", function() {
    pm.expect(result.descritivoRequisicao).to.eql(pm.collectionVariables.get("descritivoRequisicao"));
});

pm.test("Checar Status Chamado", function() {
    pm.expect(result.solucionado).not.undefined;
    pm.expect(result.solucionado).not.null;
    pm.expect(result.solucionado).to.eql(false);
});