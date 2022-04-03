using System.Data;
using EtlLocadora.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EtlLocadora.Processamento
{
    public class ProcessoEtl : IProcessoEtl
    {
        public readonly LocadoraDwContext DwContext;

        public ProcessoEtl(LocadoraDwContext dwContext)
        {
            DwContext = dwContext;
        }
        public void Processar(int opt)
        {
            switch (opt)
            {
                case 1:
                    Exclude();
                    break;
                case 2:
                    ProcessarEtl();
                    break;
            }
        }

        private void ProcessarEtl()
        {

        }

        private void Exclude()
        {
            const string cmd = "BEGIN FOR i IN(SELECT 1 ordem, 'delete from ' || table_name comando FROM dba_tables " +
                               "WHERE owner = 'DW_LOCADORA' AND table_name LIKE 'FT%' " +
                               "UNION ALL SELECT 2 ordem, 'delete from ' || table_name comando " +
                               "FROM dba_tables WHERE owner = 'DW_LOCADORA' AND TABLE_name LIKE 'DM%' " +
                               "ORDER BY 1 ) LOOP " +
                               "EXECUTE IMMEDIATE i.comando; " +
                               "END LOOP; " +
                               "END; ";
            using var command = DwContext.Database.GetDbConnection().CreateCommand();
            if (command.Connection!.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }

            command.CommandText = cmd;
            command.ExecuteNonQuery();
        }
    }
    public interface IProcessoEtl
    {
        void Processar(int opt);
    }
}
