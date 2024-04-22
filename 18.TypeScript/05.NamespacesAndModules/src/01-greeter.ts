namespace Greeter {
    export interface Greeting<T> {
        introduction(): string;

        sayGoodbye(name: T): string;
    }
}