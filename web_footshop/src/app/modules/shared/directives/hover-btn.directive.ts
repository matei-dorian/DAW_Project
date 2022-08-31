import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appHoverBtn]'
})
export class HoverBtnDirective {
  public colour: string = "blue";
  
  private highlight(color:string){
    this.el.nativeElement.style.backgroundColor = color;
  }

  constructor(
    public el: ElementRef,
  ) { this.colour = this.el.nativeElement.style.backgroundColor;}

  @HostListener('mouseenter') OnMouseEnter() {
    this.highlight('yellow');

  }

  @HostListener('mouseleave') OnMouseLeave() {
    this.highlight(this.colour);
  }

}
