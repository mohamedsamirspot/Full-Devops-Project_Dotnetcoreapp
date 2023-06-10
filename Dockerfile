#---------------------------------first stage base image---------------------------------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# This line specifies the base image for the Docker image. It uses the mcr.microsoft.com/dotnet/sdk:7.0 image, which is the .NET SDK version 7.0. This base image provides the necessary tools and environment for building .NET applications.
# The AS build part assigns a build stage name to this image. Build stages allow you to organize your Dockerfile into distinct phases, making it easier to manage and optimize the build process.
WORKDIR /source
# This line sets the working directory inside the container to /source. The WORKDIR instruction is used to define the directory where subsequent instructions will be executed.


#---------------------------------copy csproj and restore dependencies then publish appication files---------------------------------
COPY . . 
# The COPY . . step copies all the files and directories into the container, excluding the "bin" and "obj" directories as specified in the Docker ignore file. This step ensures that the actual source code files are available for the restore and build processes.
RUN dotnet restore
# This line executes the dotnet restore command inside the container. The dotnet restore command is used to restore the NuGet packages specified in the .csproj files.
# By running this command, the container retrieves and installs the required dependencies based on the information in the .csproj files. This step ensures that all the necessary packages are available for building the application.
RUN dotnet publish -c release -o /app
#This line executes the dotnet publish command inside the container. The dotnet publish command is used to build the application and publish it for deployment.
#The -c release option specifies the build configuration as "release," which typically enables optimizations and creates a release-ready version of the application.
#The -o /app option specifies the output directory for the published application. In this case, the application will be published to the /app directory inside the container.


#---------------------------------final stage image---------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:7.0
# an image specifically designed for running ASP.NET applications. It includes the necessary runtime and libraries to host and execute ASP.NET applications.
WORKDIR /app
# This line sets the working directory inside the container to /app. The WORKDIR instruction is used to define the directory where subsequent instructions will be executed. In this case, it sets the directory to /app, which is a common directory used to store application files in ASP.NET applications.
COPY --from=build /app .
# By using this instruction, you are copying the output of the build process from the previous stage (which was published to /app) into the current stage's working directory (/app). This ensures that the final image contains the necessary application files to run.
# The . represents the current directory in the current stage, which is set to /app (WORKDIR /app). Therefore, the files from the previous build stage's /app directory are being copied into the current stage's /app directory.

#expose the port for kestrel
# However, it is important to note that exposing a port in the Dockerfile does not automatically publish or map that port to the host machine. It simply serves as documentation for users or developers to understand which ports the container is intended to listen on.
EXPOSE 80


# start the asp.net core app
ENTRYPOINT [ "dotnet", "NewsSite.dll" ]
# a.dll the same as the sdafsdgfd.csproj file whatever the name
# In this case, the entrypoint is set to [ "dotnet", "a.dll" ]. It means that when the container starts, the dotnet command will be executed with a.dll as the argument.
# The dotnet command is the .NET CLI (Command-Line Interface) tool, and it is used to execute .NET applications. The a.dll is the assembly file (DLL) of the application that will be run.
# By setting the entrypoint to [ "dotnet", "a.dll" ], the container will execute the specified .NET application (a.dll) using the dotnet runtime. This assumes that the .NET runtime is properly installed in the container.