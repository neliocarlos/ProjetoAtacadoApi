﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Ancestral
{
    public abstract class BaseAncestralService<TPoco> where TPoco : class
    {
        public virtual List<TPoco> Listar()
        {
            throw new NotImplementedException("Faz ai preguiça!");
        } 

        public virtual TPoco Selecionar(int id)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TPoco Criar(TPoco obj)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TPoco Atualizar(TPoco obj)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TPoco Excluir(TPoco obj)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }

        public virtual TPoco Excluir(int id)
        {
            throw new NotSupportedException("Faz ai preguiça!");
        }
    }
}
