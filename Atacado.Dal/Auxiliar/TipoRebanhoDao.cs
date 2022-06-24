﻿using Atacado.Dal.Ancestral;
using Atacado.EF.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dal.Auxiliar
{
    public class TipoRebanhoDao : BaseAncestralDao<TipoRebanho>
    {
        public TipoRebanhoDao() : base()
        { }

        public override TipoRebanho Create(TipoRebanho obj)
        {
            this.contexto.TipoRebanhos.Add(obj);
            this.contexto.SaveChanges();
            return obj;
        }

        public override TipoRebanho Delete(int id)
        {
            TipoRebanho del = this.Read(id);
            this.contexto.TipoRebanhos.Remove(del);
            this.contexto.SaveChanges();
            return del;
        }

        public override TipoRebanho Delete(TipoRebanho obj)
        {
            return this.Delete(obj.IdTipo);
        }

        public override TipoRebanho Read(int id)
        {
            TipoRebanho obj = this.contexto.TipoRebanhos.SingleOrDefault(tip => tip.IdTipo == id);
            return obj;
        }

        public override List<TipoRebanho> ReadAll()
        {
            return this.contexto.TipoRebanhos.ToList();
        }

        public List<TipoRebanho> ReadAll(int skip, int take)
        {
            return this.contexto.TipoRebanhos.Skip(skip).Take(take).ToList();
        }

        public override TipoRebanho Update(TipoRebanho obj)
        {
            TipoRebanho alt = this.Read(obj.IdTipo);
            alt.Descricao = obj.Descricao;
            alt.Situacao = obj.Situacao;
            this.contexto.SaveChanges();
            return alt;
        }
    }
}
