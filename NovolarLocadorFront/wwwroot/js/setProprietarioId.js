document.addEventListener('DOMContentLoaded', function() {
    // Obtém o ID do locador a partir do elemento hidden
    
    var locadorId = document.getElementById('locadorId')?.value;

    // Função para atualizar o href dos links
    function updateLinkHref(linkId) {
        var linkElement = document.getElementById(linkId);
        if (linkElement && locadorId) {
            var currentHref = linkElement.getAttribute('href');
            var newHref = currentHref.includes('?') ?
                currentHref + "&id=" + locadorId :
                currentHref + "?id=" + locadorId;
            linkElement.setAttribute('href', newHref);
        }
    }

    // Atualiza os links com os IDs especificados
    updateLinkHref('vistoriaSearchBtn');
    updateLinkHref('indicadoresBtn');
    updateLinkHref('detalhesLocadorBtn');
    updateLinkHref('imovelListBtn');
    updateLinkHref('homeBtn');
});
