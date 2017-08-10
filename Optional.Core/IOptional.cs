﻿using System;

namespace Optional.Core {
    public interface IOptional<out T> {
        bool IsAbsent { get; }
        T Value { get; }
        TReturnType Handle<TReturnType>(Func<T, TReturnType> handlePresent, Func<TReturnType> handleAbsent);
    }
}