import React from 'react';
import { TouchableOpacity, Text, StyleSheet } from 'react-native';

export default function CustomButton({ title, onPress, variant = 'default' }) {
  return (
    <TouchableOpacity
      style={[
        styles.button,
        variant === 'transparent' && styles.transparent,
        variant === 'gray' && styles.gray
      ]}
      onPress={onPress}
    >
      <Text style={[
        styles.text,
        variant === 'transparent' && styles.textWhite,
        variant === 'gray' && styles.textDark
      ]}>
        {title}
      </Text>
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  button: {
    backgroundColor: 'white',
    paddingVertical: 12,
    paddingHorizontal: 30,
    borderRadius: 20,
    marginVertical: 8,
    alignItems: 'center',
  },
  transparent: {
    backgroundColor: 'rgba(255,255,255,0.1)',
  },
  gray: {
    backgroundColor: '#D9D9D9',
  },
  text: {
    fontWeight: 'bold',
    color: 'black',
  },
  textWhite: {
    color: 'white',
  },
  textDark: {
    color: 'black',
  },
});
