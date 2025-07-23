﻿const base_path = window.location.origin;
var listaProdutos = [];
var produtoML;

function produtoML() {
    var dto = {
        // Tela de Menu Produtos ML
        tblProdutosML: $('#tblProdutosML'),
        txtPesquisaProduto: $('#txtPesquisaProduto').val()

        // Tela de Cadastro Produtos ML

    };

    function pesquisarTodosProdutos() {
        limparTabela();
        $.ajax({
            url: base_path + "/ProdutoML/PesquisarTodosProdutos",
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                    JSON.parse(data.message).results.forEach(function (id) {
                        pesquisarProduto(id);
                    });
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Erro na requisição:', textStatus, errorThrown);
            }
        });
    }

    function limparTabela() {
        var tbody = $("#tblProdutosML tbody");
        tbody.empty();
        listaProdutos = [];
    }

    function pesquisarProduto(id) {
        $.ajax({
            url: base_path + "/ProdutoML/PesquisarProduto",
            data: {
                idItem: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                    listaProdutos.push(JSON.parse(data.message));
                    preencheTabelaProdutos();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Erro na requisição:', textStatus, errorThrown);
            }
        });
    }

    function preencheTabelaProdutos() {
        var tbody = $("#tblProdutosML tbody");
        tbody.empty();

        listaProdutos.forEach(function (produto) {
            const linha = $("<tr>");
            linha.append($("<td>").text(produto.id));
            linha.append($("<td>").text(produto.title));
            linha.append($("<td>").text(produto.available_quantity));
            linha.append($("<td>").text(produto.currency_id + ' ' + produto.price));
            const botoes = $(`
                <td>
                    <a class="text-decoration-none" style="cursor:pointer" onclick="atualizarProduto('${produto.id}')">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-fill" viewBox="0 0 16 16">
                            <path d="M12.854.146a.5.5 0 0 0-.707 0L10.5 1.793 14.207 5.5l1.647-1.646a.5.5 0 0 0 0-.708zm.646 6.061L9.793 2.5 3.293 9H3.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.207zm-7.468 7.468A.5.5 0 0 1 6 13.5V13h-.5a.5.5 0 0 1-.5-.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.5-.5V10h-.5a.5.5 0 0 1-.175-.032l-.179.178a.5.5 0 0 0-.11.168l-2 5a.5.5 0 0 0 .65.65l5-2a.5.5 0 0 0 .168-.11z"></path>
                        </svg>
                    </a>
                    <a class="bi bi-trash-fill" style="cursor:pointer" onclick="deletarProduto('${produto.id}')">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                            <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5M8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5m3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0"></path>
                        </svg>
                    </a>
                </td>
            `);
            linha.append(botoes);
            tbody.append(linha);
        });

    }

    function cadastroProduto() {
        $.ajax({
            url: base_path + "/ProdutoML/CadastroProduto",
            type: 'GET',
            dataType: 'html',
            success: function (data) {
                if (data.success) {
                    listaProdutos.push(JSON.parse(data.message));
                    preencheTabelaProdutos();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Erro na requisição:', textStatus, errorThrown);
            }
        });
    }

    return {
        pesquisarTodosProdutos: pesquisarTodosProdutos,
        pesquisarProduto: pesquisarProduto,
        preencheTabelaProdutos: preencheTabelaProdutos,
        limparTabela: limparTabela,
        cadastroProduto: cadastroProduto
    }
}

// Garante que tudo está pronto para usar após o carregamento da página
$(document).ready(function () {
    produtoML = produtoML();
    produtoML().pesquisarTodosProdutos();

    $('#btnPesquisarProduto').on('click', function (e) {
        var idProduto = $('#txtPesquisaProduto').val();
        if ($('#txtPesquisaProduto').val() == '')
            produtoML().pesquisarTodosProdutos();
        else {
            produtoML().limparTabela();
            produtoML().pesquisarProduto(idProduto);
        }
    });

    $('#btnCadastrarProduto').on('click', function (e) {
        produtoML.cadastroProduto();
    });
});
