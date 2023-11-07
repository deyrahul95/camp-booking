export class Helper {
  padZero = (num: number, pad: number) => num.toString().padStart(pad, '0');
  date = new Date();

  Today(): string {
    var today =
      this.date.getFullYear() +
      '-' +
      this.padZero(this.date.getMonth() + 1, 2) +
      '-' +
      this.padZero(this.date.getDate(), 2);
    return today;
  }

  Tomorrow(): string {
    var tomorrow =
      this.date.getFullYear() +
      '-' +
      this.padZero(this.date.getMonth() + 1, 2) +
      '-' +
      this.padZero(this.date.getDate() + 1, 2);
    return tomorrow;
  }

  GetDiffDays(sDate: string, eDate: string): number {
    var startDate = new Date(sDate);
    var endDate = new Date(eDate);

    var Time = endDate.getTime() - startDate.getTime();
    return Time / (1000 * 3600 * 24);
  }
}
