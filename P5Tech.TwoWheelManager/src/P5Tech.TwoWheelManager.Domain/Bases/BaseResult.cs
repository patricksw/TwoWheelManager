using System;
using System.Collections.Generic;

namespace P5Tech.TwoWheelManager.Domain.Bases
{
    public class BaseResult
    {
        public List<string> Mensagens { get; set; }

        public Exception Erro { get; set; }

        public BaseResult()
        {
            Mensagens = [];
        }

        public BaseResult(string mensagem, Exception ex)
        {
            Mensagens = [mensagem];
            Erro = ex;
        }

        public BaseResult(List<string> mensagens, Exception ex)
        {
            Mensagens = mensagens;
            Erro = ex;
        }
        public BaseResult(string mensagem) => Mensagens = [mensagem];

        public BaseResult(List<string> mensagens) => Mensagens = mensagens;

    }

    public class BaseResult<T> : BaseResult
    {
        public BaseResult() : base() { }
        public BaseResult(string mensagem) : base(mensagem) { }
        public BaseResult(string mensagem, Exception ex) : base(mensagem, ex) { }
        public T Data { get; set; }
        public static BaseResult<T> New(T value) => new() { Data = value };
    }
}