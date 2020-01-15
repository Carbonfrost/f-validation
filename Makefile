.PHONY: dotnet/generate dotnet/test

## Generate generated code
dotnet/generate:
	srgen -c Carbonfrost.Commons.Validation.Resources.SR \
		-r Carbonfrost.Commons.Validation.Automation.SR \
		--resx \
		dotnet/src/Carbonfrost.Commons.Validation/Automation/SR.properties

## Build the dotnet solution
dotnet/build:
	@ eval $(shell eng/build_env); \
		dotnet build --configuration $(CONFIGURATION) ./dotnet

## Execute dotnet unit tests
dotnet/test: dotnet/publish -dotnet/test

-dotnet/test:
	fspec -i dotnet/test/Carbonfrost.UnitTests.Validation/Content \
		dotnet/test/Carbonfrost.UnitTests.Validation/bin/$(CONFIGURATION)/netcoreapp3.0/publish/Carbonfrost.Commons.Core.dll \
		dotnet/test/Carbonfrost.UnitTests.Validation/bin/$(CONFIGURATION)/netcoreapp3.0/publish/Carbonfrost.Commons.Validation.dll \
		dotnet/test/Carbonfrost.UnitTests.Validation/bin/$(CONFIGURATION)/netcoreapp3.0/publish/Carbonfrost.UnitTests.Validation.dll

## Run unit tests with code coverage
dotnet/cover: dotnet/publish -check-command-coverlet
	coverlet \
		--target "make" \
		--targetargs "-- -dotnet/test" \
		--format lcov \
		--output lcov.info \
		--exclude-by-attribute 'Obsolete' \
		--exclude-by-attribute 'GeneratedCode' \
		--exclude-by-attribute 'CompilerGenerated' \
		dotnet/test/Carbonfrost.UnitTests.Validation/bin/$(CONFIGURATION)/netcoreapp3.0/publish/Carbonfrost.UnitTests.Validation.dll


include eng/.mk/*.mk
