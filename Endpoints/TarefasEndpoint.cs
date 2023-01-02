using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using TarefaApiDapper.Data;
using static TarefaApiDapper.Data.TarefaContext;

namespace TarefaApiDapper.Endpoints
{
    public static class TarefasEndpoint
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/",() => $"Bem vindos a API de Tarefas {DateTime.Now.Date}");

            //Retorna uma lista de tarefas
            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter(); //abre e fecha a conexão ao banco automaticamente.
                var tarefas = con.GetAll<Tarefa>().ToList();
                if(tarefas is null) return Results.NotFound();

                return Results.Ok(tarefas); 
            });

            app.MapGet("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                var tarefa = con.Get<Tarefa>(id);
                if(tarefa is null) return Results.NotFound();

                return Results.Ok(tarefa);
            });

            app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefa tarefaInput)=>
            {
                using var con = await connectionGetter();
                var id = con.Insert(tarefaInput);
                
                return Results.Created($"tarefas/{id}", tarefaInput);
            });

            app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefa tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(tarefa);

                return Results.Ok();
            });

            app.MapDelete("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                var deleted = con.Get<Tarefa>(id);

                if(deleted is null) return Results.NotFound();

                con.Delete(deleted);

                return Results.Ok(deleted);
            });
        }
    }
}