using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
    deploymentName: "gpt35t",
    endpoint: "https://aoai24.openai.azure.com/",
    apiKey: "756fa86ba7af4f11b4523e098adf5e16",
    modelId: "gpt-35-turbo" // optional
);

var kernel = builder.Build();

Console.WriteLine("Welcome to the Restaurant Booking Copilot!");

await Task.Delay(1500);

Console.WriteLine("What would you like to do today?");

var input = Console.ReadLine();

string prompt = $@"<message role=""system"">Identify the user's intent. Return one of the following values: 
Booking - If the user wants to create a restaurant booking.
CancelBooking - If the user wants to cancel a restaurant booking.
ChangeBooking - If the user wants to change a restaurant booking.
Questions - If the user has questions about the restaurant.
Unknown - If the user's intent matches none of the above.</message>

for example:
<message role=""user"">I want to make a restaurant booking for today</message>
<message role=""assistant"">Booking</message>

<message role=""user"">Where is the restaurant?</message>
<message role=""assistant"">Questions</message>

<message role=""user"">I want to make a change in my booking time</message>
<message role=""assistant"">ChangeBooking</message>

<message role=""user"">I want to know where the nearest planet from me is</message>
<message role=""assistant"">Unknown</message>

<message role=""user"">${input}</message>";

var result = await kernel.InvokePromptAsync(
        prompt);
    Console.WriteLine(result);