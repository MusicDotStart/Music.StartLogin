function playByteArray(bytes) {
    var buffer = new Uint8Array(bytes.length);
    buffer.set(new Uint8Array(bytes), 0);

    context.decodeAudioData(buffer.buffer, play);
}

function play(audioBuffer) {
    var source = context.createBufferSource();
    source.buffer = audioBuffer;
    source.connect(context.destination);
    source.start(0);
}