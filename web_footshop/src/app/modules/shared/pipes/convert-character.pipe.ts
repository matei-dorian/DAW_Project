import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'convertCharacter'
})
export class ConvertCharacterPipe implements PipeTransform{
    transform(value: string, initialChr: string, transformedChr: string): string {
        return value.replace(new RegExp(initialChr, "g"), transformedChr);
    }

}