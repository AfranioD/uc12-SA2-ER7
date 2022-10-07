using System.Text.RegularExpressions;
using CadastroPessoaUc12.Interfaces;

namespace CadastroPessoaUc12.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {

        public string? Cnpj { get; set; }

        public string? RazaoSocial { get; set; }



        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * .03f;

            }else if (rendimento <= 6000)
            {
                
                return rendimento * .05f;

            }else if (rendimento <= 10000)
            {
                return rendimento * .07f;

            }else
            {
                return rendimento * .09f;
            }
        }

        //xx.xxx.xxx/0001-xx

        public bool ValidarCnpj(string cnpj)
        {

            //forma abaixo esta simplificada na condição logo abaixo.

            // bool returnoCnpjValido = Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)");

            // if (returnoCnpjValido == true)
           
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18)
                 {
                    string subStringCnpj = cnpj.Substring(11, 4);

                    if (subStringCnpj == "0001") 
                    {
                        return true;
                    }

                 }else if (cnpj.Length == 14) 
                 {
                    string subStringCnpj = cnpj.Substring(8, 4);

                    if (subStringCnpj == "0001")
                    {
                        return true;
                    }
                 }
            }
            return false;

        }
    }
}