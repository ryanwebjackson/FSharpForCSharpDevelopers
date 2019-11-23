/// Evolutionary computation module:
/// this module is for Genetic Algorithm (GA) only
module EvolutionaryComputation

  open System.Collections.Generic
  
  /// random number generator (RNG)
  let random = new System.Random((int)System.DateTime.UtcNow.Ticks)
  
  let randomF() = random.Next()
  
  let randomFloatF() = random.NextDouble()
  
  type ChromosomeType(f, size, ?converters) =
      let initialF = f
      let mutable genos = [for i in 1..size do yield f()]
      let mutable genoPhenoConverters = converters
      
      member this.Clone() =
          let newValue =
              match converters with
                  | Some(converters) -> new ChromosomeType(initialF, size, converters)
                  | None -> new ChromosomeType(initialF, size)
          newValue.Genos <- this.Genos
          newValue
          
      member this.Genos
          with get() = genos
          and set(value) = genos <- value
          
      member this.Fitness(fitnessFunction) = this.Pheno |> fitnessFunction
      
      member this.Pheno
          with get() =
            match genoPhenoConverters with
            | Some(genoPhenoConverters) -> List.zip genoPhenoConverters genos |> List.map (fun (f, value) -> f value)
            | None -> this.Genos
  
  printfn "result: %i" (random.Next())
  //printfn "result: %A" (((new ChromosomeType(f = randomF, size = 12345)).Genos)).ToString())
