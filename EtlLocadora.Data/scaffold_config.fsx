open System
open System.IO

let caminho_appsettings = "EtlLocadora.Processamento/appsettings.json"
let projeto_do_contexto = "EtlLocadora.Data"
let nome_do_contexto = "LocadoraContext"
let diretorio_do_contexto = "Context"
let diretorio_das_entidades = "..\EtlLocadora.Data\Domain\Entities"
let projeto_das_entidades = "EtlLocadora.Data"
let caminho_string_conexao = "$.ConnectionStrings.LocadoraContext" 
let driver_banco_de_dados = "Oracle.EntityFrameworkCore"

// Comandos do terminal
let restore = "dotnet restore"

let run str = 
    System.Diagnostics.Process.Start("CMD.exe","/C " + str).WaitForExit()

//let addRef ref = "dotnet add " + projeto_do_contexto + " reference " + ref

let scaffold_str connection_string= //table_list =
    //let table_str = table_list |> List.map(fun table -> " -t " + table) |> String.concat ""
    [ 
        "dotnet ef dbcontext scaffold \"" + connection_string + "\""
        driver_banco_de_dados
        "-v"
        "-f"
        "--context-dir " + diretorio_do_contexto
        "-c " + nome_do_contexto
        "-o " + diretorio_das_entidades
        "--no-onconfiguring"
        "--no-pluralize"
        "--project " + projeto_do_contexto
        //table_str
    ] |> String.concat " "

let addPackage pkg = "dotnet add " + projeto_do_contexto + " package " + pkg
//

let scaffold() =
    let conexao = "User Id=SYSTEM;Password=Oracle18;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST =localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XE)))"
    run <| scaffold_str conexao //tabelas
    //run <| addRef projeto_das_entidades

let install() =
    run <| addPackage "Microsoft.EntityFrameworkCore.Design"
    run <| addPackage "Microsoft.EntityFrameworkCore.Tools"
    run <| addPackage driver_banco_de_dados
    run restore
    printf "Pacotes instalados, gerar scaffold? (y/n) "
    let resposta = Console.ReadLine()
    if resposta = "y" then 
        scaffold()
    else
        ()

let rec main () =
    printf "Deseja instalar os pacotes para geracao automatica do scaffold? (y/n) "
    let resposta = String.map (Char.ToLower) (Console.ReadLine())

    match resposta with
    | "y" -> install()
    | "n" -> scaffold()
    | _   -> main()

main()