﻿using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoTresCamadas
{
    public partial class TelaFornecedor : Form
    {
        public TelaFornecedor()
        {
            InitializeComponent();
        }

        Fornecedor forn;

        private void CarregaTabela()
        {
            forn = new Fornecedor();
            DgvDados.DataSource = forn.Pesquisar();
        }

        private void TelaFornecedor_Load(object sender, EventArgs e)
        {
            CarregaTabela();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Cnpj = txtCnpj.Text;
            forn.Email = txtEmail.Text;
            forn.Telefone = txtTelefone.Text;
            forn.Razao = txtRazao.Text;
            MessageBox.Show(forn.Gravar() ? "Salvo com sucesso!" : "Não foi possivel salvar!");
            CarregaTabela();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = int.Parse(txtId.Text);
            if (forn.Excluir())
                MessageBox.Show("Excluido com sucesso!");
            else
                MessageBox.Show("Não foi possivel excluir!");
            CarregaTabela();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            forn = new Fornecedor();
            forn.Id = int.Parse(txtId.Text);
            forn.Cnpj = txtCnpj.Text;
            forn.Email = txtEmail.Text;
            forn.Telefone = txtTelefone.Text;
            forn.Razao = txtRazao.Text;
            MessageBox.Show(forn.Atualizar() ? "Atualizado com sucesso!" : "Não foi possivel atualizar!");
            CarregaTabela();
        }

        private void DgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            forn.Id = Convert.ToInt32(DgvDados["forn_id", e.RowIndex].Value);
            DataTable dt = forn.PesquisarId();
            txtId.Text = dt.Rows[0]["forn_id"].ToString();
            txtCnpj.Text = dt.Rows[0]["forn_cnpj"].ToString();
            txtEmail.Text = dt.Rows[0]["forn_email"].ToString();
            txtRazao.Text = dt.Rows[0]["forn_razao"].ToString();
            txtTelefone.Text = dt.Rows[0]["forn_telefone"].ToString();
        }
    }
}
