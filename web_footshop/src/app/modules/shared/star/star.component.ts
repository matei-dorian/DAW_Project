import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from "@angular/core";

@Component({
    selector: 'fs-star',
    templateUrl: './star.component.html',
    styleUrls: ['./star.component.scss']
})
export class StarComponent implements OnChanges {
    ngOnChanges(changes: SimpleChanges): void {
        this.cropWidth = this.rating * 75 / 5;
    }
    
    @Input() public rating: number = 0;
    @Output() ratingClicked : EventEmitter<string> = new EventEmitter<string>();
    public cropWidth: number = 75;

    onClick(): void {
        this.ratingClicked.emit(`The rating ${this.rating} was clicked`)
    }
}