using ADOWithSPOutputParam;

var data = DbCallWithSpOutputParam.CallStoredProcWithOutputParam(3);

Console.WriteLine($"Age: {data.age}, Name: {data.name}, Status: {data.status}");
